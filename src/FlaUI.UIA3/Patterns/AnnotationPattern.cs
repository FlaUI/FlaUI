using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.UIA3.Converters;
using FlaUI.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Patterns
{
    public class AnnotationPattern : AnnotationPatternBase<UIA.IUIAutomationAnnotationPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_AnnotationPatternId, "Annotation", AutomationObjectIds.IsAnnotationPatternAvailableProperty);
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target").SetConverter(AutomationElementConverter.NativeToManaged);

        public AnnotationPattern(FrameworkAutomationElementBase frameworkAutomationElement, UIA.IUIAutomationAnnotationPattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }
    }

    public class AnnotationPatternPropertyIds : IAnnotationPatternPropertyIds
    {
        public PropertyId AnnotationTypeId => AnnotationPattern.AnnotationTypeIdProperty;
        public PropertyId AnnotationTypeName => AnnotationPattern.AnnotationTypeNameProperty;
        public PropertyId Author => AnnotationPattern.AuthorProperty;
        public PropertyId DateTime => AnnotationPattern.DateTimeProperty;
        public PropertyId Target => AnnotationPattern.TargetProperty;
    }
}
