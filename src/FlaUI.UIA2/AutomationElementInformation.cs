using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Shapes;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
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
        public static readonly PropertyId AutomationIdProperty = PropertyId.Register(AutomationLibraryType.UIA2, UIA.AutomationElementIdentifiers.AutomationIdProperty.Id, "AutomationId");
        public static readonly PropertyId BoundingRectangleProperty = PropertyId.Register(AutomationLibraryType.UIA2, UIA.AutomationElementIdentifiers.BoundingRectangleProperty.Id, "BoundingRectangle").SetConverter(o => { var rect = (System.Windows.Rect)o; return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height); });
        public static readonly PropertyId NameProperty = PropertyId.Register(AutomationLibraryType.UIA2, UIA.AutomationElementIdentifiers.NameProperty.Id, "Name");
        #endregion Ids
    }
}
