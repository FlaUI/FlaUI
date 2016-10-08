using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IAnnotationPattern : IPatternWithInformation<IAnnotationPatternInformation>
    {
        IAnnotationPatternProperties Properties { get; }
    }

    public interface IAnnotationPatternInformation : IPatternInformation
    {
        AnnotationType AnnotationType { get; }
        string AnnotationTypeName { get; }
        string Author { get; }
        string DateTime { get; }
        AutomationElement Target { get; }
    }

    public interface IAnnotationPatternProperties
    {
        PropertyId AnnotationTypeIdProperty { get; }
        PropertyId AnnotationTypeNameProperty { get; }
        PropertyId AuthorProperty { get; }
        PropertyId DateTimeProperty { get; }
        PropertyId TargetProperty { get; }
    }
}
