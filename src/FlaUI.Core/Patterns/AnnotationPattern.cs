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
        PropertyId AnnotationTypeId { get; }
        PropertyId AnnotationTypeName { get; }
        PropertyId Author { get; }
        PropertyId DateTime { get; }
        PropertyId Target { get; }
    }

    public abstract class AnnotationPatternBase<TNativePattern> : PatternBase<TNativePattern>, IAnnotationPattern
    {
        protected AnnotationPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            AnnotationType = new AutomationProperty<AnnotationType>(() => Properties.AnnotationTypeId, BasicAutomationElement);
            AnnotationTypeName = new AutomationProperty<string>(() => Properties.AnnotationTypeName, BasicAutomationElement);
            Author = new AutomationProperty<string>(() => Properties.Author, BasicAutomationElement);
            DateTime = new AutomationProperty<string>(() => Properties.DateTime, BasicAutomationElement);
            Target = new AutomationProperty<AutomationElement>(() => Properties.Target, BasicAutomationElement);
        }

        public IAnnotationPatternProperties Properties => Automation.PropertyLibrary.Annotation;

        public AutomationProperty<AnnotationType> AnnotationType { get; }
        public AutomationProperty<string> AnnotationTypeName { get; }
        public AutomationProperty<string> Author { get; }
        public AutomationProperty<string> DateTime { get; }
        public AutomationProperty<AutomationElement> Target { get; }
    }
}
