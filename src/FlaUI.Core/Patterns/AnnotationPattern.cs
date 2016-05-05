using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class AnnotationPattern : PatternBaseWithInformation<IUIAutomationAnnotationPattern, AnnotationPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA_PatternIds.UIA_AnnotationPatternId, "Annotation");
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target");

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
