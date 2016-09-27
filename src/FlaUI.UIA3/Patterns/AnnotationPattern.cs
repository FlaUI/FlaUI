using FlaUI.Core;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.Core.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class AnnotationPattern : PatternBaseWithInformation<AnnotationPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_AnnotationPatternId, "Annotation");
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target");

        internal AnnotationPattern(Element automationElement, UIA.IUIAutomationAnnotationPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new AnnotationPatternInformation(element, cached))
        {
        }

        public new UIA.IUIAutomationAnnotationPattern NativePattern
        {
            get { return (UIA.IUIAutomationAnnotationPattern)base.NativePattern; }
        }
    }

    public class AnnotationPatternInformation : InformationBase
    {
        public AnnotationPatternInformation(Element automationElement, bool cached)
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

        public Element Target
        {
            get { return NativeElementToElement(AnnotationPattern.TargetProperty); }
        }
    }
}
