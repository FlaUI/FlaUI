using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ITextPattern : IPattern
    {
        ITextPatternEventIds EventIds { get; }

        ITextRange DocumentRange { get; }
        SupportedTextSelection SupportedTextSelection { get; }

        ITextRange[] GetSelection();
        ITextRange[] GetVisibleRanges();
        ITextRange RangeFromChild(AutomationElement child);
        ITextRange RangeFromPoint(Point point);
    }

    public interface ITextPatternEventIds
    {
        EventId TextChangedEvent { get; }
        EventId TextSelectionChangedEvent { get; }
    }

    public abstract class TextPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITextPattern
        where TNativePattern : class
    {
        protected TextPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ITextPatternEventIds EventIds => Automation.EventLibrary.Text;

        public abstract ITextRange DocumentRange { get; }
        public abstract SupportedTextSelection SupportedTextSelection { get; }

        public abstract ITextRange[] GetSelection();
        public abstract ITextRange[] GetVisibleRanges();
        public abstract ITextRange RangeFromChild(AutomationElement child);
        public abstract ITextRange RangeFromPoint(Point point);
    }
}
