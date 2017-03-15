using FlaUI.Core.Shapes;

namespace FlaUI.Core
{
    public interface IAutomationElementInformation
    {
        string AutomationId { get; }
        Rectangle BoundingRectangle { get; }
        string Name { get; }
    }
}
