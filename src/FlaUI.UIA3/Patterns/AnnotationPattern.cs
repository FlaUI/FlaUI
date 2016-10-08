using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA3.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class AnnotationPattern : PatternBaseWithInformation<UIA.IUIAutomationAnnotationPattern, AnnotationPatternInformation>, IAnnotationPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_AnnotationPatternId, "Annotation");
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target");

        public AnnotationPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationAnnotationPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            Properties = new AnnotationPatternProperties();
        }

        IAnnotationPatternInformation IPatternWithInformation<IAnnotationPatternInformation>.Cached => Cached;

        IAnnotationPatternInformation IPatternWithInformation<IAnnotationPatternInformation>.Current => Current;

        public IAnnotationPatternProperties Properties { get; }

        protected override AnnotationPatternInformation CreateInformation(bool cached)
        {
            return new AnnotationPatternInformation(BasicAutomationElement, cached);
        }
    }

    public class AnnotationPatternInformation : InformationBase, IAnnotationPatternInformation
    {
        public AnnotationPatternInformation(BasicAutomationElementBase basicAutomationElement, bool cached) : base(basicAutomationElement, cached)
        {
        }

        public AnnotationType AnnotationType => Get<AnnotationType>(AnnotationPattern.AnnotationTypeIdProperty);

        public string AnnotationTypeName => Get<string>(AnnotationPattern.AnnotationTypeNameProperty);

        public string Author => Get<string>(AnnotationPattern.AuthorProperty);

        public string DateTime => Get<string>(AnnotationPattern.DateTimeProperty);

        public AutomationElement Target
        {
            get
            {
                var nativeElement = Get<UIA.IUIAutomationElement>(AnnotationPattern.TargetProperty);
                return NativeValueConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeElement);
            }
        }
    }

    public class AnnotationPatternProperties : IAnnotationPatternProperties
    {
        public PropertyId AnnotationTypeIdProperty => AnnotationPattern.AnnotationTypeIdProperty;
        public PropertyId AnnotationTypeNameProperty => AnnotationPattern.AnnotationTypeNameProperty;
        public PropertyId AuthorProperty => AnnotationPattern.AuthorProperty;
        public PropertyId DateTimeProperty => AnnotationPattern.DateTimeProperty;
        public PropertyId TargetProperty => AnnotationPattern.TargetProperty;
    }
}
