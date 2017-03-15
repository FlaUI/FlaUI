using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// A description of a single parameter
    /// 
    /// This does not match a UIA structure, but is used as a simple data class
    /// to help form those structures.
    /// </summary>
    public class UiaParameterDescription
    {
        private readonly string _name;
        private readonly UIAutomationType _uiaType;

        public UiaParameterDescription(string name, UIAutomationType type)
        {
            _name = name;
            _uiaType = type;
        }

        public string Name
        {
            get { return _name; }
        }

        public UIAutomationType UiaType
        {
            get { return _uiaType; }
        }
    }
}