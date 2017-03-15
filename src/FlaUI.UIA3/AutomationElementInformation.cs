using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3
{
    public class AutomationElementInformation : InformationBase2, IAutomationElementInformation
    {
        public AutomationElementInformation(AutomationElementBase automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public string AutomationId { get { return Get<string>(AutomationIdProperty); } }
        public Rectangle BoundingRectangle { get { return Get<Rectangle>(BoundingRectangleProperty); } }
        public string Name { get { return Get<string>(NameProperty); } }

        #region Ids
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(AutomationLibraryType.UIA3, UIA.UIA_PropertyIds.UIA_AutomationIdPropertyId, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(AutomationLibraryType.UIA3, UIA.UIA_PropertyIds.UIA_BoundingRectanglePropertyId, "BoundingRectangle").SetConverter(NativeValueConverter.ToRectangle);        
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationLibraryType.UIA3, UIA.UIA_PropertyIds.UIA_NamePropertyId, "Name");
        #endregion Ids
    }
}
