using FlaUI.Core;
using FlaUI.Core.Identifiers;
using FlaUI.UIA2.Converters;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Identifiers
{
    public static class TextAttributes
    {
        public static readonly TextAttributeId AnimationStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.AnimationStyleAttribute.Id, "AnimationStyle");
        public static readonly TextAttributeId BackgroundColor = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.BackgroundColorAttribute.Id, "BackgroundColor");
        public static readonly TextAttributeId BulletStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.BulletStyleAttribute.Id, "BulletStyle");
        public static readonly TextAttributeId CapStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.CapStyleAttribute.Id, "CapStyle");
        public static readonly TextAttributeId Culture = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.CultureAttribute.Id, "Culture").SetConverter((a, o) => ValueConverter.ToCulture(o));
        public static readonly TextAttributeId FontName = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.FontNameAttribute.Id, "FontName");
        public static readonly TextAttributeId FontSize = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.FontSizeAttribute.Id, "FontSize");
        public static readonly TextAttributeId FontWeight = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.FontWeightAttribute.Id, "FontWeight");
        public static readonly TextAttributeId ForegroundColor = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.ForegroundColorAttribute.Id, "ForegroundColor");
        public static readonly TextAttributeId HorizontalTextAlignment = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.HorizontalTextAlignmentAttribute.Id, "HorizontalTextAlignment");
        public static readonly TextAttributeId IndentationFirstLine = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IndentationFirstLineAttribute.Id, "IndentationFirstLine");
        public static readonly TextAttributeId IndentationLeading = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IndentationLeadingAttribute.Id, "IndentationLeading");
        public static readonly TextAttributeId IndentationTrailing = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IndentationTrailingAttribute.Id, "IndentationTrailing");
        public static readonly TextAttributeId IsHidden = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IsHiddenAttribute.Id, "IsHidden");
        public static readonly TextAttributeId IsItalic = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IsItalicAttribute.Id, "IsItalic");
        public static readonly TextAttributeId IsReadOnly = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IsReadOnlyAttribute.Id, "IsReadOnly");
        public static readonly TextAttributeId IsSubscript = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IsSubscriptAttribute.Id, "IsSubscript");
        public static readonly TextAttributeId IsSuperscript = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.IsSuperscriptAttribute.Id, "IsSuperscript");
        public static readonly TextAttributeId MarginBottom = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.MarginBottomAttribute.Id, "MarginBottom");
        public static readonly TextAttributeId MarginLeading = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.MarginLeadingAttribute.Id, "MarginLeading");
        public static readonly TextAttributeId MarginTop = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.MarginTopAttribute.Id, "MarginTop");
        public static readonly TextAttributeId MarginTrailing = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.MarginTrailingAttribute.Id, "MarginTrailing");
        public static readonly TextAttributeId OutlineStyles = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.OutlineStylesAttribute.Id, "OutlineStyles");
        public static readonly TextAttributeId OverlineColor = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.OverlineColorAttribute.Id, "OverlineColor");
        public static readonly TextAttributeId OverlineStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.OverlineStyleAttribute.Id, "OverlineStyle");
        public static readonly TextAttributeId StrikethroughColor = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.StrikethroughColorAttribute.Id, "StrikethroughColor");
        public static readonly TextAttributeId StrikethroughStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.StrikethroughStyleAttribute.Id, "StrikethroughStyle");
        public static readonly TextAttributeId Tabs = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.TabsAttribute.Id, "Tabs");
        public static readonly TextAttributeId TextFlowDirections = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.TextFlowDirectionsAttribute.Id, "TextFlowDirections");
        public static readonly TextAttributeId UnderlineColor = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.UnderlineColorAttribute.Id, "UnderlineColor");
        public static readonly TextAttributeId UnderlineStyle = TextAttributeId.Register(AutomationType.UIA2, UIA.TextPatternIdentifiers.UnderlineStyleAttribute.Id, "UnderlineStyle");
    }
}
