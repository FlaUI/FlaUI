using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class ElementViewModel : ObservableObject
    {
        public event Action<ElementViewModel> SelectionChanged;

        public ElementViewModel(AutomationElement automationElement)
        {
            AutomationElement = automationElement;
            Children = new ExtendedObservableCollection<ElementViewModel>();
            ItemDetails = new ExtendedObservableCollection<DetailGroupViewModel>();
        }

        public AutomationElement AutomationElement { get; }

        public bool IsSelected
        {
            get { return GetProperty<bool>(); }
            set
            {
                SetProperty(value);
                if (value)
                {
                    ElementHighlighter.HighlightElement(AutomationElement);
                    // Async load details
                    var task = Task.Run(() =>
                    {
                        var details = LoadDetails();
                        return details;
                    }).ContinueWith(items =>
                    {
                        ItemDetails.Reset(items.Result);
                    }, TaskScheduler.FromCurrentSynchronizationContext());

                    // Fire the selection event
                    SelectionChanged?.Invoke(this);
                }
            }
        }

        public bool IsExpanded
        {
            get { return GetProperty<bool>(); }
            set
            {
                SetProperty(value);
                if (value)
                {
                    LoadChildren(true);
                }
            }
        }

        public string Name => NormalizeString(AutomationElement.Current.Name);
        public string AutomationId => NormalizeString(AutomationElement.Current.AutomationId);
        public ControlType ControlType => AutomationElement.Current.ControlType;
        public ExtendedObservableCollection<ElementViewModel> Children { get; set; }
        public ExtendedObservableCollection<DetailGroupViewModel> ItemDetails { get; set; }

        public void LoadChildren(bool loadInnerChildren)
        {
            foreach (var child in Children)
            {
                child.SelectionChanged -= SelectionChanged;
            }
            var childrenViewModels = new List<ElementViewModel>();
            foreach (var child in AutomationElement.FindAll(TreeScope.Children, new TrueCondition(), TimeSpan.Zero))
            {
                var childViewModel = new ElementViewModel(child);
                childViewModel.SelectionChanged += SelectionChanged;
                childrenViewModels.Add(childViewModel);
                if (loadInnerChildren)
                {
                    childViewModel.LoadChildren(false);
                }
            }
            Children.Reset(childrenViewModels);
        }

        private List<DetailGroupViewModel> LoadDetails()
        {
            var detailGroups = new List<DetailGroupViewModel>();
            // Element identification
            var identification = new List<DetailViewModel>
            {
                new DetailViewModel("AutomationId", AutomationElement.Current.AutomationId),
                new DetailViewModel("Name", AutomationElement.Current.Name),
                new DetailViewModel("ClassName", AutomationElement.Current.ClassName),
                new DetailViewModel("ControlType", AutomationElement.Current.ControlType),
                new DetailViewModel("LocalizedControlType", AutomationElement.Current.LocalizedControlType),
                new DetailViewModel("FrameworkType", AutomationElement.FrameworkType),
                new DetailViewModel("FrameworkId", AutomationElement.Current.FrameworkId),
                new DetailViewModel("ProcessId", AutomationElement.Current.ProcessId),
            };
            detailGroups.Add(new DetailGroupViewModel("Identification", identification));

            // Element details
            var details = new List<DetailViewModel>
            {
                new DetailViewModel("IsEnabled", AutomationElement.Current.IsEnabled),
                new DetailViewModel("IsOffscreen", AutomationElement.Current.IsOffscreen),
                new DetailViewModel("BoundingRectangle", AutomationElement.Current.BoundingRectangle),
                new DetailViewModel("HelpText", AutomationElement.Current.HelpText),
                new DetailViewModel("IsPassword", AutomationElement.Current.IsPassword),
                new DetailViewModel("NativeWindowHandle", String.Format("{0} ({0:X8})", AutomationElement.Current.NativeWindowHandle.ToInt32()))
            };
            detailGroups.Add(new DetailGroupViewModel("Details", details));

            // Pattern details
            var allSupportedPatterns = AutomationElement.BasicAutomationElement.GetSupportedPatterns();
            var allPatterns = AutomationElement.Automation.PatternLibrary.AllSupportedPatterns;
            var patterns = new List<DetailViewModel>();
            foreach (var pattern in allPatterns)
            {
                patterns.Add(new DetailViewModel(pattern.Name + "Pattern", allSupportedPatterns.Contains(pattern) ? "Yes" : "No"));
            }
            detailGroups.Add(new DetailGroupViewModel("Pattern Support", patterns));

            // TODO: Add all missing pattern properties
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.RangeValuePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetRangeValuePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsReadOnly", pattern.Current.IsReadOnly),
                    new DetailViewModel("SmallChange", pattern.Current.SmallChange),
                    new DetailViewModel("LargeChange", pattern.Current.LargeChange),
                    new DetailViewModel("Minimum", pattern.Current.Minimum),
                    new DetailViewModel("Maximum", pattern.Current.Maximum),
                    new DetailViewModel("Value", pattern.Current.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("RangeValue Pattern", patternDetails));
            }

            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TogglePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetTogglePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("ToggleState", pattern.Current.ToggleState)
                };
                detailGroups.Add(new DetailGroupViewModel("Toggle Pattern", patternDetails));
            }

            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.ValuePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetValuePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsReadOnly", pattern.Current.IsReadOnly),
                    new DetailViewModel("Value", pattern.Current.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("Value Pattern", patternDetails));
            }

            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.WindowPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetWindowPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsModal", pattern.Current.IsModal),
                    new DetailViewModel("IsTopmost", pattern.Current.IsTopmost),
                    new DetailViewModel("CanMinimize", pattern.Current.CanMinimize),
                    new DetailViewModel("CanMaximize", pattern.Current.CanMaximize),
                    new DetailViewModel("WindowVisualState", pattern.Current.WindowVisualState),
                    new DetailViewModel("WindowInteractionState", pattern.Current.WindowInteractionState)
                };
                detailGroups.Add(new DetailGroupViewModel("Window Pattern", patternDetails));
            }

            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.LegacyIAccessiblePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetLegacyIAccessiblePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("Name", pattern.Current.Name),
                    new DetailViewModel("State", AccessibilityTextResolver.GetStateText(pattern.Current.State)),
                    new DetailViewModel("Role", AccessibilityTextResolver.GetRoleText(pattern.Current.Role)),
                    new DetailViewModel("Value", pattern.Current.Value),
                    new DetailViewModel("ChildId", pattern.Current.ChildId),
                    new DetailViewModel("DefaultAction", pattern.Current.DefaultAction),
                    new DetailViewModel("Description", pattern.Current.Description),
                    new DetailViewModel("Help", pattern.Current.Help),
                    new DetailViewModel("KeyboardShortcut", pattern.Current.KeyboardShortcut),
                    new DetailViewModel("Selection", pattern.Current.Selection)
                };
                detailGroups.Add(new DetailGroupViewModel("LegacyIAccessible Pattern", patternDetails));
            }

            return detailGroups;
        }

        private string NormalizeString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Replace(Environment.NewLine, " ").Replace('\r', ' ').Replace('\n', ' ');
        }
    }
}
