using System;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Helper class to gather data about a custom property
    /// Corresponds to UIAutomationPropertyInfo
    /// </summary>
    public class UiaPropertyInfoHelper : ISchemaMember
    {
        private readonly Guid _propertyGuid;
        private readonly string _programmaticName;
        private readonly UIAutomationType _propertyType;
        private readonly Func<object, object> _getterFromProvider;
        private bool _built;
        private UIAutomationPropertyInfo _data;

        /// <summary>
        /// Suitable for standalone properties that do not require handlers, hence no need to use ISchemaMember.DispatchCallToProvider() ever.
        /// </summary>
        public UiaPropertyInfoHelper(Guid propertyGuid, string programmaticName, UIAutomationType propertyType)
            :this(propertyGuid, programmaticName, propertyType, null)
        {
        }

        /// <summary>
        /// Usable for general-purpose implementation that uses ISchemaMember.DispatchCallToProvider()
        /// </summary>
        /// <param name="getterFromProvider">Lambda for getting property value from pattern provider interface. It should be akin to
        /// <code>(object p) => ((ISomePatternProvider)p).MyProperty</code>. Or, same thing, 
        /// <code>TypeMember&lt;ISomePatternProvider&gt;.GetPropertyGetter(p => p.MyProperty)</code>. For standalone properties
        /// it can be null (it is used for pattern handler implementation only, which doesn't take part in getting standalone properties).</param>
        public UiaPropertyInfoHelper(Guid propertyGuid, string programmaticName, UIAutomationType propertyType, Func<object, object> getterFromProvider)
        {
            _programmaticName = programmaticName;
            _propertyGuid = propertyGuid;
            _propertyType = propertyType;
            _getterFromProvider = getterFromProvider;
        }

        /// <summary>
        /// Get a marshalled UIAutomationPropertyInfo struct for this Helper.
        /// </summary>
        public UIAutomationPropertyInfo Data
        {
            get
            {
                if (!_built)
                    Build();
                return _data;
            }
        }

        /// <summary>
        /// The UIA type of this property
        /// </summary>
        public UIAutomationType UiaType
        {
            get { return _propertyType; }
        }

        /// <summary>
        /// The unique identifier for this property
        /// </summary>
        public Guid Guid
        {
            get { return _propertyGuid; }
        }

        /// <summary>
        /// The index of this property, when it is used as part of a pattern
        /// </summary>
        public uint Index { get; set; }

        /// <summary>
        /// The property ID of this property, assigned after registration
        /// </summary>
        public int PropertyId { get; set; }

        private void Build()
        {
            _data = new UIAutomationPropertyInfo
                    {
                        pProgrammaticName = _programmaticName,
                        guid = _propertyGuid,
                        type = _propertyType
                    };
            _built = true;
        }

        public void DispatchCallToProvider(object provider, UiaParameterListHelper paramList)
        {
            if (_getterFromProvider == null)
                throw new InvalidOperationException("You have to provide getterFromProvider lambda argument to constructor in order to use this method");
            if (paramList.Count != 1) 
                throw new ArgumentException("For a property param list should contain only one out param");
            paramList[0] = _getterFromProvider(provider);
        }

        public bool SupportsDispatch
        {
            get { return _getterFromProvider != null; }
        }
    }
}