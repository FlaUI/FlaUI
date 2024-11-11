﻿using FlaUI.Core.AutomationElements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface ISelectionPattern : IPattern
    {
        ISelectionPatternPropertyIds PropertyIds { get; }
        ISelectionPatternEventIds EventIds { get; }

        AutomationProperty<bool> CanSelectMultiple { get; }
        AutomationProperty<bool> IsSelectionRequired { get; }
        AutomationProperty<AutomationElement[]> Selection { get; }
    }

    public interface ISelectionPatternPropertyIds
    {
        PropertyId CanSelectMultiple { get; }
        PropertyId IsSelectionRequired { get; }
        PropertyId Selection { get; }
    }

    public interface ISelectionPatternEventIds
    {
        EventId InvalidatedEvent { get; }
    }

    public abstract class SelectionPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISelectionPattern
        where TNativePattern : class
    {
        private AutomationProperty<bool>? _canSelectMultiple;
        private AutomationProperty<bool>? _isSelectionRequired;
        private AutomationProperty<AutomationElement[]>? _selection;

        protected SelectionPatternBase(FrameworkAutomationElementBase frameworkAutomationElement, TNativePattern nativePattern) : base(frameworkAutomationElement, nativePattern)
        {
        }

        public ISelectionPatternPropertyIds PropertyIds => Automation.PropertyLibrary.Selection;
        public ISelectionPatternEventIds EventIds => Automation.EventLibrary.Selection;

        public AutomationProperty<bool> CanSelectMultiple => GetOrCreate(ref _canSelectMultiple, PropertyIds.CanSelectMultiple);
        public AutomationProperty<bool> IsSelectionRequired => GetOrCreate(ref _isSelectionRequired, PropertyIds.IsSelectionRequired);
        public AutomationProperty<AutomationElement[]> Selection => GetOrCreate(ref _selection, PropertyIds.Selection);
    }
}
