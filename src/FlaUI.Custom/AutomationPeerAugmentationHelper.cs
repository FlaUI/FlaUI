using System;
using System.Collections;
using System.Reflection;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Threading;
using Castle.DynamicProxy;

namespace ManagedUiaCustomizationCore
{
    public static class AutomationPeerAugmentationHelper
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        public static void Register(CustomPatternSchemaBase schema)
        {
            //   For events AutomationPeers goes other way and list of events it can raise through 
            // AutomationPeer.RaiseAutomationEvent() is very strictly hardcoded with switch()
            // operator in the EventMap internal class. But it is possible to get IRawElementProviderSimple
            // from the protected AutomationPeer.ProviderFromPeer method and use it directly via
            // NativeMethods.UiaRaiseAutomationEvent. Basically it is the same AutomationPeer does, 
            // so the only inconvenience would be non-standard method of raising.
            //   Another piece required here is to replicate for AutomationPeer.ListenersExist(). Seems to
            // fully support custom events we would have to rewrite EventsMap class. Fortunately it is small :)
            //
            // TODO: Add support for raising custom UIA events

            RegisterPattern(schema);
            foreach (var property in schema.Properties)
                RegisterProperty(property);
            if (schema.StandaloneProperties != null)
            {
                foreach (var uiaPropertyInfoHelper in schema.StandaloneProperties)
                {
                    var automationProperty = RegisterProperty(uiaPropertyInfoHelper);
                    RegisterStandalonePropertyGetter(automationProperty);
                }
            }
        }

        private static void RegisterPattern(CustomPatternSchemaBase schema)
        {
            var automationPeerType = typeof(AutomationPeer);
            // The only purpose of this method is to construct and correctly execute these lines of code:
            //
            //   var wrapper = new Wrapper(schema.PatternProviderInterface);
            //   var wrapObject = new AutomationPeer.WrapObject(wrapper.WrapObjectReplacer);
            //   AutomationPeer.s_patternInfo[schema.PatternId] 
            //      = new AutomationPeer.PatternInfo(schema.PatternId, 
            //                                       wrapObject, 
            //                                       (PatternInterface)schema.PatternId);
            //   AutomationPattern.Register(schema.PatternGuid, schema.PatternName);
            //
            //   The problem here is that AutomationPeer.WrapObject, AutomationPeer.s_patternInfo, AutomationPattern.Register
            // and AutomationPeer.PatternInfo are not public, so we need some hardcore reflection.
            //   Now, to be very clear, casting patternId to PatternInterface is not totally correct, 
            // but customly registered patterns get IDs near 50000 and max PatternInterface value is 
            // something about 20, so they won't intersect ever. On the other hand, after several hours
            // studying AutomationPeer sources it seems unfeasible to get what we need in other way 
            // because AutomationPeer wasn't written with extensibility in mind.
            var patternInfoHashtableField = automationPeerType.GetField("s_patternInfo", BindingFlags.NonPublic | BindingFlags.Static);

            // from AutomationPeer.cs: private delegate object WrapObject(AutomationPeer peer, object iface);
            var wrapObjectDelegateType = automationPeerType.GetNestedType("WrapObject", BindingFlags.NonPublic);
            var wrapper = new Wrapper(schema.PatternProviderInterface);
            var wrapObjectReplacerMethodInfo = ReflectionUtils.GetMethodInfo(() => wrapper.WrapObjectReplacer(null, null));
            var wrapObject = Delegate.CreateDelegate(wrapObjectDelegateType, wrapper, wrapObjectReplacerMethodInfo);
            
            // from AutomationPeer.cs:  
            //private class PatternInfo
            //{
            //  internal int Id;
            //  internal AutomationPeer.WrapObject WrapObject;
            //  internal PatternInterface PatternInterface;

            //  internal PatternInfo(int id, AutomationPeer.WrapObject wrapObject, PatternInterface patternInterface)
            //  {
            //    this.Id = id;
            //    this.WrapObject = wrapObject;
            //    this.PatternInterface = patternInterface;
            //  }
            //}
            var patternInfoType = automationPeerType.GetNestedType("PatternInfo", BindingFlags.NonPublic);
            var patternInfoTypeCtor = patternInfoType.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                binder: null,
                types: new[] {typeof(int), wrapObjectDelegateType, typeof(PatternInterface)},
                modifiers: null);
            var patternInfo = patternInfoTypeCtor.Invoke(new object[] {schema.PatternId, wrapObject, (PatternInterface)schema.PatternId});

            var automationPatternType = typeof(AutomationPattern);
            var registerMethod = automationPatternType.GetMethod("Register", BindingFlags.NonPublic | BindingFlags.Static);

            using (Dispatcher.CurrentDispatcher.DisableProcessing())
            {
                var patternInfoHashtable = (Hashtable)patternInfoHashtableField.GetValue(null);
                if (patternInfoHashtable.Contains(schema.PatternId)) return;
                patternInfoHashtable[schema.PatternId] = patternInfo;
                registerMethod.Invoke(null, new object[] {schema.PatternGuid, schema.PatternName});
            }
        }

        private static void RegisterStandalonePropertyGetter(AutomationProperty automationProperty)
        {
            // With WPF Automation peers, retrieving UIA property value goes through these steps:
            //  1. UIA request comes at ElementProxy which linked with AutomationPeer and wraps it from multithreading, COM etc
            //  2. ElementProxy passes request to UI thread and directs it to AutomationPeer.GetPropertyValue(int propertyId)
            //  3. AutomationPeer consults its hashtable of getters and tries to find there getter for required property. These 
            //     getters are basically Func<AutomationPeer, object>
            //  4. If getter is found - it is called like getter(this) from AutomationPeer, otherwise null returned
            //
            // Similarly to RegisterPattern() method, we need to add new item to 
            // private static Hashtable AutomationPeer.s_propertyInfo, in order to let 3rd step from above pass correctly
            // Like this line
            //   AutomationPeer.s_propertyInfo[property.PropertyId] = new AutomationPeer.GetProperty(getter);
            // where GetProperty defined in AutomationPeer as:
            //   private delegate object GetProperty(AutomationPeer peer);
            //
            // Our getter will try to cast AutomationPeer to IStandalonePropertyProvider and if successful - get result from it.
            // Otherwise returns null.
            var automationPeerType = typeof(AutomationPeer);
            var propertyInfoHashtableField = automationPeerType.GetField("s_propertyInfo", BindingFlags.NonPublic | BindingFlags.Static);
            var getterDelegateType = automationPeerType.GetNestedType("GetProperty", BindingFlags.NonPublic);
            var getterObject = new StandalonePropertyGetter(automationProperty);
            var getterMethodInfo = ReflectionUtils.GetMethodInfo(() => getterObject.Getter(null));
            var getter = Delegate.CreateDelegate(getterDelegateType, getterObject, getterMethodInfo);

            using (Dispatcher.CurrentDispatcher.DisableProcessing())
            {
                var propertyHashtable = (Hashtable)propertyInfoHashtableField.GetValue(null);
                propertyHashtable[automationProperty.Id] = getter;
            }
        }

        private static AutomationProperty RegisterProperty(UiaPropertyInfoHelper property)
        {
            var automationPropertyType = typeof(AutomationProperty);
            var registerMethod = automationPropertyType.GetMethod("Register", BindingFlags.NonPublic | BindingFlags.Static);

            using (Dispatcher.CurrentDispatcher.DisableProcessing())
                return (AutomationProperty)registerMethod.Invoke(null, new object[] { property.Guid, property.Data.pProgrammaticName });
        }

        // we have to capture providerInterfaceType; as lambda captures are ony compiler syntactic sugar - we
        // have to recreate its magic here by hand
        private class Wrapper
        {
            private readonly Type _providerInterfaceType;

            public Wrapper(Type providerInterfaceType)
            {
                _providerInterfaceType = providerInterfaceType;
            }

            public object WrapObjectReplacer(AutomationPeer peer, object iface)
            {
                var interceptor = new SendingToUIThreadInterceptor(peer);
                return _proxyGenerator.CreateInterfaceProxyWithTarget(_providerInterfaceType, iface, interceptor);
            }
        }

        private static void GuardUiaServerInvocation(Action invocation, Dispatcher dispatcher)
        {
            if (dispatcher == null)
                throw new InvalidOperationException("Dispatcher is not available. Maybe it is not a UI thread?");
            Exception remoteException = null;
            bool completed = false;
            dispatcher.Invoke(DispatcherPriority.Send, TimeSpan.FromMinutes(3.0), (Action)(() =>
            {
                try
                {
                    invocation();
                }
                catch (Exception e)
                {
                    remoteException = e;
                }
                catch
                {
                    remoteException = null;
                }
                finally
                {
                    completed = true;
                }
            }));
            if (completed)
            {
                if (remoteException != null)
                    throw remoteException;
            }
            else if (dispatcher.HasShutdownStarted)
                throw new InvalidOperationException("AutomationDispatcherShutdown");
            else
                throw new TimeoutException("AutomationTimeout");
        }

        private class StandalonePropertyGetter
        {
            private readonly AutomationProperty _property;

            public StandalonePropertyGetter(AutomationProperty property)
            {
                _property = property;
            }

            public object Getter(AutomationPeer peer)
            {
                var propertyProvider = peer as IStandalonePropertyProvider;
                if (propertyProvider == null) return null;
                object result = null;
                GuardUiaServerInvocation(() => result = propertyProvider.GetPropertyValue(_property), peer.Dispatcher);
                return result;
            }
        }

        private class SendingToUIThreadInterceptor : IInterceptor
        {
            private readonly Dispatcher _dispatcher;

            public SendingToUIThreadInterceptor(AutomationPeer peer)
            {
                _dispatcher = peer.Dispatcher;
            }

            public void Intercept(IInvocation invocation)
            {
                GuardUiaServerInvocation(invocation.Proceed, _dispatcher);
            }
        }
    }
}
