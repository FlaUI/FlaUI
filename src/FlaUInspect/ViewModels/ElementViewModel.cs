using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlaUI.Core;
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

        public string TryGet(Func<string> func)
        {
            try
            {
                var property = AutomationElement.Info.Name;
                return NormalizeString(property);
            }
            catch (Exception ex)
            {
                return "Not Supported";
            }
        }
        
        public string Name => TryGet(() => AutomationElement.Info.Name);

        public string AutomationId => TryGet(() => AutomationElement.Info.AutomationId);

        public ControlType ControlType => AutomationElement.Info.ControlType;

        public ExtendedObservableCollection<ElementViewModel> Children { get; set; }

        public ExtendedObservableCollection<DetailGroupViewModel> ItemDetails { get; set; }

        public string XPath => Debug.GetXPathToElement(AutomationElement);

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
                new DetailViewModel("AutomationId", AutomationElement.Info.AutomationId),
                new DetailViewModel("Name", AutomationElement.Info.Name),
                new DetailViewModel("ClassName", AutomationElement.Info.ClassName),
                new DetailViewModel("ControlType", AutomationElement.Info.ControlType),
                new DetailViewModel("LocalizedControlType", AutomationElement.Info.LocalizedControlType),
                new DetailViewModel("FrameworkType", AutomationElement.FrameworkType),
                new DetailViewModel("FrameworkId", AutomationElement.Info.FrameworkId),
                new DetailViewModel("ProcessId", AutomationElement.Info.ProcessId),
            };
            detailGroups.Add(new DetailGroupViewModel("Identification", identification));

            // Element details
            var details = new List<DetailViewModel>
            {
                new DetailViewModel("IsEnabled", AutomationElement.Info.IsEnabled),
                new DetailViewModel("IsOffscreen", AutomationElement.Info.IsOffscreen),
                new DetailViewModel("BoundingRectangle", AutomationElement.Info.BoundingRectangle),
                new DetailViewModel("HelpText", AutomationElement.Info.HelpText),
                new DetailViewModel("IsPassword", AutomationElement.Info.IsPassword),
                new DetailViewModel("NativeWindowHandle", String.Format("{0} ({0:X8})", AutomationElement.Info.NativeWindowHandle.ToInt32()))
            };
            detailGroups.Add(new DetailGroupViewModel("Details", details));

            // Pattern details
            var allSupportedPatterns = AutomationElement.BasicAutomationElement.GetSupportedPatterns();
            var allPatterns = AutomationElement.Automation.PatternLibrary.AllForCurrentFramework;
            var patterns = new List<DetailViewModel>();
            foreach (var pattern in allPatterns)
            {
                var hasPattern = allSupportedPatterns.Contains(pattern);
                patterns.Add(new DetailViewModel(pattern.Name + "Pattern", hasPattern ? "Yes" : "No") { Important = hasPattern });
            }
            detailGroups.Add(new DetailGroupViewModel("Pattern Support", patterns));

            // TODO: Add all missing pattern properties
            // GridItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.GridItemPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetGridItemPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("Column", pattern.Column),
                    new DetailViewModel("ColumnSpan", pattern.ColumnSpan),
                    new DetailViewModel("Row", pattern.Row),
                    new DetailViewModel("RowSpan", pattern.RowSpan),
                    new DetailViewModel("ContainingGrid", pattern.ContainingGrid)
                };
                detailGroups.Add(new DetailGroupViewModel("GridItem Pattern", patternDetails));
            }
            // GridPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.GridPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetGridPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("ColumnCount", pattern.ColumnCount),
                    new DetailViewModel("RowCount", pattern.RowCount)
                };
                detailGroups.Add(new DetailGroupViewModel("Grid Pattern", patternDetails));
            }
            // LegacyIAccessiblePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.LegacyIAccessiblePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetLegacyIAccessiblePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("Name", pattern.Name),
                    new DetailViewModel("State", AccessibilityTextResolver.GetStateText(pattern.State)),
                    new DetailViewModel("Role", AccessibilityTextResolver.GetRoleText(pattern.Role)),
                    new DetailViewModel("Value", pattern.Value),
                    new DetailViewModel("ChildId", pattern.ChildId),
                    new DetailViewModel("DefaultAction", pattern.DefaultAction),
                    new DetailViewModel("Description", pattern.Description),
                    new DetailViewModel("Help", pattern.Help),
                    new DetailViewModel("KeyboardShortcut", pattern.KeyboardShortcut),
                    new DetailViewModel("Selection", pattern.Selection)
                };
                detailGroups.Add(new DetailGroupViewModel("LegacyIAccessible Pattern", patternDetails));
            }
            // RangeValuePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.RangeValuePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetRangeValuePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsReadOnly", pattern.IsReadOnly),
                    new DetailViewModel("SmallChange", pattern.SmallChange),
                    new DetailViewModel("LargeChange", pattern.LargeChange),
                    new DetailViewModel("Minimum", pattern.Minimum),
                    new DetailViewModel("Maximum", pattern.Maximum),
                    new DetailViewModel("Value", pattern.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("RangeValue Pattern", patternDetails));
            }
            // ScrollPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.ScrollPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetScrollPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("HorizontalScrollPercent", pattern.HorizontalScrollPercent),
                    new DetailViewModel("HorizontalViewSize", pattern.HorizontalViewSize),
                    new DetailViewModel("HorizontallyScrollable", pattern.HorizontallyScrollable),
                    new DetailViewModel("VerticalScrollPercent", pattern.VerticalScrollPercent),
                    new DetailViewModel("VerticalViewSize", pattern.VerticalViewSize),
                    new DetailViewModel("VerticallyScrollable", pattern.VerticallyScrollable)
                };
                detailGroups.Add(new DetailGroupViewModel("Scroll Pattern", patternDetails));
            }
            // SelectionItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.SelectionItemPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetSelectionItemPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsSelected", pattern.IsSelected),
                    new DetailViewModel("SelectionContainer", pattern.SelectionContainer)
                };
                detailGroups.Add(new DetailGroupViewModel("SelectionItem Pattern", patternDetails));
            }
            // SelectionPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.SelectionPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetSelectionPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("Selection", pattern.Selection),
                    new DetailViewModel("CanSelectMultiple", pattern.CanSelectMultiple),
                    new DetailViewModel("IsSelectionRequired", pattern.IsSelectionRequired)
                };
                detailGroups.Add(new DetailGroupViewModel("Selection Pattern", patternDetails));
            }
            // TableItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TableItemPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetTableItemPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("ColumnHeaderItems", pattern.ColumnHeaderItems),
                    new DetailViewModel("RowHeaderItems", pattern.RowHeaderItems)
                };
                detailGroups.Add(new DetailGroupViewModel("TableItem Pattern", patternDetails));
            }
            // TablePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TablePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetTablePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("ColumnHeaderItems", pattern.ColumnHeaders),
                    new DetailViewModel("RowHeaderItems", pattern.RowHeaders),
                    new DetailViewModel("RowOrColumnMajor", pattern.RowOrColumnMajor)
                };
                detailGroups.Add(new DetailGroupViewModel("Table Pattern", patternDetails));
            }
            // TogglePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TogglePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetTogglePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("ToggleState", pattern.ToggleState)
                };
                detailGroups.Add(new DetailGroupViewModel("Toggle Pattern", patternDetails));
            }
            // ValuePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.ValuePattern))
            {
                var pattern = AutomationElement.PatternFactory.GetValuePattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsReadOnly", pattern.IsReadOnly),
                    new DetailViewModel("Value", pattern.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("Value Pattern", patternDetails));
            }
            // WindowPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.WindowPattern))
            {
                var pattern = AutomationElement.PatternFactory.GetWindowPattern();
                var patternDetails = new List<DetailViewModel>
                {
                    new DetailViewModel("IsModal", pattern.IsModal),
                    new DetailViewModel("IsTopmost", pattern.IsTopmost),
                    new DetailViewModel("CanMinimize", pattern.CanMinimize),
                    new DetailViewModel("CanMaximize", pattern.CanMaximize),
                    new DetailViewModel("WindowVisualState", pattern.WindowVisualState),
                    new DetailViewModel("WindowInteractionState", pattern.WindowInteractionState)
                };
                detailGroups.Add(new DetailGroupViewModel("Window Pattern", patternDetails));
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
