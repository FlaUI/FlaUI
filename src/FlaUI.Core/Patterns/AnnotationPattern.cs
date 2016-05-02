using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class AnnotationPattern : PatternBase<IUIAutomationAnnotationPattern>
    {
        public static readonly AutomationPattern Pattern = AutomationPattern.Register(UIA_PatternIds.UIA_AnnotationPatternId, "Annotation");
        public static readonly AutomationProperty AnnotationTypeIdProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly AutomationProperty AnnotationTypeNameProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly AutomationProperty AuthorProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly AutomationProperty DateTimeProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly AutomationProperty TargetProperty = AutomationProperty.Register(UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target");

        public AnnotationPatternInformation Cached { get; private set; }

        public AnnotationPatternInformation Current { get; private set; }

        internal AnnotationPattern(AutomationElement automationElement, IUIAutomationAnnotationPattern nativePattern)
            : base(automationElement, nativePattern)
        {
            Cached = new AnnotationPatternInformation(AutomationElement, true);
            Current = new AnnotationPatternInformation(AutomationElement, false);
        }

        public class AnnotationPatternInformation : InformationBase
        {
            public AnnotationPatternInformation(AutomationElement automationElement, bool cached)
                : base(automationElement, cached)
            {
            }

            public AnnotationType AnnotationType
            {
                get { return AutomationElement.SafeGetPropertyValue<AnnotationType>(AnnotationTypeIdProperty, Cached); }
            }

            public string AnnotationTypeName
            {
                get { return AutomationElement.SafeGetPropertyValue<string>(AnnotationTypeNameProperty, Cached); }
            }

            public string Author
            {
                get { return AutomationElement.SafeGetPropertyValue<string>(AuthorProperty, Cached); }
            }

            public string DateTime
            {
                get { return AutomationElement.SafeGetPropertyValue<string>(DateTimeProperty, Cached); }
            }

            public AutomationElement Target
            {
                get { return NativeElementToElement(TargetProperty); }
            }
        }
    }
}
