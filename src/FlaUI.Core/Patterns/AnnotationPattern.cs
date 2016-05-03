using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class AnnotationPattern : PatternBaseWithInformation<IUIAutomationAnnotationPattern, AnnotationPatternInformation>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_AnnotationPatternId, "Annotation");
        public static readonly AutomationProperty AnnotationTypeIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly AutomationProperty AnnotationTypeNameProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly AutomationProperty AuthorProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly AutomationProperty DateTimeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly AutomationProperty TargetProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target");

        internal AnnotationPattern(AutomationElement automationElement, IUIAutomationAnnotationPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new AnnotationPatternInformation(element, cached))
        {
        }
    }

    public class AnnotationPatternInformation : InformationBase
    {
        public AnnotationPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public AnnotationType AnnotationType
        {
            get { return Get<AnnotationType>(AnnotationPattern.AnnotationTypeIdProperty); }
        }

        public string AnnotationTypeName
        {
            get { return Get<string>(AnnotationPattern.AnnotationTypeNameProperty); }
        }

        public string Author
        {
            get { return Get<string>(AnnotationPattern.AuthorProperty); }
        }

        public string DateTime
        {
            get { return Get<string>(AnnotationPattern.DateTimeProperty); }
        }

        public AutomationElement Target
        {
            get { return NativeElementToElement(AnnotationPattern.TargetProperty); }
        }
    }
}
