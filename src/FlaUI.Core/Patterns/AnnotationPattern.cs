using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IAnnotationPattern : IPattern
    {
        IAnnotationPatternProperties Properties { get; }

        AutomationProperty<AnnotationType> AnnotationType { get; }
        AutomationProperty<string> AnnotationTypeName { get; }
        AutomationProperty<string> Author { get; }
        AutomationProperty<string> DateTime { get; }
        AutomationProperty<AutomationElement> Target { get; }
    }

    public interface IAnnotationPatternProperties
    {
        PropertyId AnnotationTypeIdProperty { get; }
        PropertyId AnnotationTypeNameProperty { get; }
        PropertyId AuthorProperty { get; }
        PropertyId DateTimeProperty { get; }
        PropertyId TargetProperty { get; }
    }

    public abstract class AnnotationPatternBase<TNativePattern> : PatternBase<TNativePattern>, IAnnotationPattern
    {
        protected AnnotationPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            AnnotationType = new AutomationProperty<AnnotationType>(() => Properties.AnnotationTypeIdProperty, BasicAutomationElement);
            AnnotationTypeName = new AutomationProperty<string>(() => Properties.AnnotationTypeNameProperty, BasicAutomationElement);
            Author = new AutomationProperty<string>(() => Properties.AuthorProperty, BasicAutomationElement);
            DateTime = new AutomationProperty<string>(() => Properties.DateTimeProperty, BasicAutomationElement);
            Target = new AutomationProperty<AutomationElement>(() => Properties.TargetProperty, BasicAutomationElement);
        }

        public IAnnotationPatternProperties Properties => Automation.PropertyLibrary.Annotation;

        public AutomationProperty<AnnotationType> AnnotationType { get; }
        public AutomationProperty<string> AnnotationTypeName { get; }
        public AutomationProperty<string> Author { get; }
        public AutomationProperty<string> DateTime { get; }
        public AutomationProperty<AutomationElement> Target { get; }
    }
}
