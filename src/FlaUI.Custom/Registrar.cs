using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Automation.Peers;
using System.Windows.Threading;
using Interop.UIAutomationCore;

namespace FlaUI.Custom
{
    public static class Registrar
    {
        public static void RegisterPattern()
        {
            var patternInfor = new UIAutomationPatternInfo
            {
                guid = Guid.NewGuid(),
            };

            var meth = new UIAutomationMethodInfo();
            meth.pParameterTypes =  Marshal.AllocCoTaskMem((int)(cTotalParameters * Marshal.SizeOf(typeof(Int32))));
            typePointer = (IntPtr)(typePointer.ToInt64() + Marshal.SizeOf(typeof(Int32)));
            var uiaRegistrar = new CUIAutomationRegistrarClass();
            uiaRegistrar.RegisterPattern();
        }

        public static void RegisterStandaloneProperty(CustomProperty customProperty)
        {
            RegisterPropertyInUIA3(customProperty);
            RegisterPropertyInWpf(customProperty);
        }

        /// <summary>
        /// Registers the property in UIA itself.
        /// </summary>
        public static void RegisterPropertyInUIA3(CustomProperty customProperty)
        {
            var propertyInfo = new UIAutomationPropertyInfo
            {
                guid = customProperty.Guid,
                pProgrammaticName = customProperty.Name,
                type = PropertyTypeHelper.ToNative(customProperty.Type)
            };

            var uiaRegistrar = new CUIAutomationRegistrarClass();
            uiaRegistrar.RegisterProperty(ref propertyInfo, out var propertyId);
            customProperty.Id = propertyId;
        }

        /// <summary>
        /// Registers the property getter in the WPF AutomationPeer.
        /// </summary>
        public static void RegisterPropertyInWpf(CustomProperty automationProperty)
        {
            // With WPF Automation peers, retrieving UIA property value goes through these steps:
            //  1. UIA request comes at ElementProxy which linked with AutomationPeer and wraps it from multi-threading, COM etc
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

        private class StandalonePropertyGetter
        {
            private readonly CustomProperty _property;

            public StandalonePropertyGetter(CustomProperty property)
            {
                _property = property;
            }

            public object Getter(AutomationPeer peer)
            {
                var propertyProvider = peer as IStandalonePropertyProvider;
                if (propertyProvider == null) return null;
                var result = propertyProvider.GetPropertyValue(_property);
                return result;
            }
        }
    }
}
