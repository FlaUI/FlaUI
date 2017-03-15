using System;
using Castle.DynamicProxy;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    public class AttributeDrivenPatternHandler : IUIAutomationPatternHandler
    {
        private static readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private readonly CustomPatternSchemaBase _schema;

        public AttributeDrivenPatternHandler(CustomPatternSchemaBase schema)
        {
            _schema = schema;
        }

        public void CreateClientWrapper(IUIAutomationPatternInstance pPatternInstance, out object pClientWrapper)
        {
            var interceptor = new PatternClientInstanceInterceptor(_schema, pPatternInstance);
            pClientWrapper = _proxyGenerator.CreateInterfaceProxyWithoutTarget(_schema.PatternClientInterface, interceptor);
        }

        public void Dispatch(object pTarget, uint index, UIAutomationParameter[] pParams, uint cParams)
        {
            ISchemaMember dispatchingMember = _schema.GetMemberByIndex(index);
            if (dispatchingMember == null)
                throw new NotSupportedException("Dispatching of this method is not supported");

            dispatchingMember.DispatchCallToProvider(pTarget, new UiaParameterListHelper(pParams));
        }
    }
}