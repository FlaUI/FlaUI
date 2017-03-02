using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
                        if (items.IsFaulted)
                        {
                            MessageBox.Show(items.Exception.ToString());
                        }
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

        public string Name => AutomationElement.Properties.Name.ValueOrDefault;

        public string AutomationId => AutomationElement.Properties.AutomationId.ValueOrDefault;

        public ControlType ControlType => AutomationElement.Properties.ControlType.Value;

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
            var cacheRequest = new CacheRequest();
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.AutomationId);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.Name);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.ClassName);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.ControlType);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.LocalizedControlType);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.FrameworkId);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.ProcessId);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.IsEnabled);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.IsOffscreen);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.BoundingRectangle);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.HelpText);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.IsPassword);
            cacheRequest.Add(AutomationElement.Automation.PropertyLibrary.Element.NativeWindowHandle);
            using (cacheRequest.Activate())
            {
                var elementCached = AutomationElement.FindFirst(TreeScope.Element, new TrueCondition());
                // Element identification
                var identification = new List<IDetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("AutomationId", elementCached.Properties.AutomationId),
                    DetailViewModel.FromAutomationProperty("Name", elementCached.Properties.Name),
                    DetailViewModel.FromAutomationProperty("ClassName", elementCached.Properties.ClassName),
                    DetailViewModel.FromAutomationProperty("ControlType", elementCached.Properties.ControlType),
                    DetailViewModel.FromAutomationProperty("LocalizedControlType", elementCached.Properties.LocalizedControlType),
                    new DetailViewModel("FrameworkType", elementCached.FrameworkType.ToString()),
                    DetailViewModel.FromAutomationProperty("FrameworkId", elementCached.Properties.FrameworkId),
                    DetailViewModel.FromAutomationProperty("ProcessId", elementCached.Properties.ProcessId),
                };
                detailGroups.Add(new DetailGroupViewModel("Identification", identification));

                // Element details
                var details = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("IsEnabled", elementCached.Properties.IsEnabled),
                    DetailViewModel.FromAutomationProperty("IsOffscreen", elementCached.Properties.IsOffscreen),
                    DetailViewModel.FromAutomationProperty("BoundingRectangle", elementCached.Properties.BoundingRectangle),
                    DetailViewModel.FromAutomationProperty("HelpText", elementCached.Properties.HelpText),
                    DetailViewModel.FromAutomationProperty("IsPassword", elementCached.Properties.IsPassword)
                };
                // Special handling for NativeWindowHandle
                var nativeWindowHandle = elementCached.Properties.NativeWindowHandle.ValueOrDefault;
                var nativeWindowHandleString = "Not Supported";
                if (nativeWindowHandle != default(IntPtr))
                {
                    nativeWindowHandleString = String.Format("{0} ({0:X8})", nativeWindowHandle.ToInt32());
                }
                details.Add(new DetailViewModel("NativeWindowHandle", nativeWindowHandleString));
                detailGroups.Add(new DetailGroupViewModel("Details", details));
            }

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

            // GridItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.GridItemPattern))
            {
                var pattern = AutomationElement.Patterns.GridItem.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("Column", pattern.Column),
                    DetailViewModel.FromAutomationProperty("ColumnSpan", pattern.ColumnSpan),
                    DetailViewModel.FromAutomationProperty("Row", pattern.Row),
                    DetailViewModel.FromAutomationProperty("RowSpan", pattern.RowSpan),
                    DetailViewModel.FromAutomationProperty("ContainingGrid", pattern.ContainingGrid)
                };
                detailGroups.Add(new DetailGroupViewModel("GridItem Pattern", patternDetails));
            }
            // GridPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.GridPattern))
            {
                var pattern = AutomationElement.Patterns.Grid.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("ColumnCount", pattern.ColumnCount),
                    DetailViewModel.FromAutomationProperty("RowCount", pattern.RowCount)
                };
                detailGroups.Add(new DetailGroupViewModel("Grid Pattern", patternDetails));
            }
            // LegacyIAccessiblePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.LegacyIAccessiblePattern))
            {
                var pattern = AutomationElement.Patterns.LegacyIAccessible.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                   DetailViewModel.FromAutomationProperty("Name", pattern.Name),
                   new DetailViewModel("State", AccessibilityTextResolver.GetStateText(pattern.State.ValueOrDefault)),
                   new DetailViewModel("Role", AccessibilityTextResolver.GetRoleText(pattern.Role.ValueOrDefault)),
                   DetailViewModel.FromAutomationProperty("Value", pattern.Value),
                   DetailViewModel.FromAutomationProperty("ChildId", pattern.ChildId),
                   DetailViewModel.FromAutomationProperty("DefaultAction", pattern.DefaultAction),
                   DetailViewModel.FromAutomationProperty("Description", pattern.Description),
                   DetailViewModel.FromAutomationProperty("Help", pattern.Help),
                   DetailViewModel.FromAutomationProperty("KeyboardShortcut", pattern.KeyboardShortcut),
                   DetailViewModel.FromAutomationProperty("Selection", pattern.Selection)
                };
                detailGroups.Add(new DetailGroupViewModel("LegacyIAccessible Pattern", patternDetails));
            }
            // RangeValuePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.RangeValuePattern))
            {
                var pattern = AutomationElement.Patterns.RangeValue.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                   DetailViewModel.FromAutomationProperty("IsReadOnly", pattern.IsReadOnly),
                   DetailViewModel.FromAutomationProperty("SmallChange", pattern.SmallChange),
                   DetailViewModel.FromAutomationProperty("LargeChange", pattern.LargeChange),
                   DetailViewModel.FromAutomationProperty("Minimum", pattern.Minimum),
                   DetailViewModel.FromAutomationProperty("Maximum", pattern.Maximum),
                   DetailViewModel.FromAutomationProperty("Value", pattern.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("RangeValue Pattern", patternDetails));
            }
            // ScrollPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.ScrollPattern))
            {
                var pattern = AutomationElement.Patterns.Scroll.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("HorizontalScrollPercent", pattern.HorizontalScrollPercent),
                    DetailViewModel.FromAutomationProperty("HorizontalViewSize", pattern.HorizontalViewSize),
                    DetailViewModel.FromAutomationProperty("HorizontallyScrollable", pattern.HorizontallyScrollable),
                    DetailViewModel.FromAutomationProperty("VerticalScrollPercent", pattern.VerticalScrollPercent),
                    DetailViewModel.FromAutomationProperty("VerticalViewSize", pattern.VerticalViewSize),
                    DetailViewModel.FromAutomationProperty("VerticallyScrollable", pattern.VerticallyScrollable)
                };
                detailGroups.Add(new DetailGroupViewModel("Scroll Pattern", patternDetails));
            }
            // SelectionItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.SelectionItemPattern))
            {
                var pattern = AutomationElement.Patterns.SelectionItem.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("IsSelected", pattern.IsSelected),
                    DetailViewModel.FromAutomationProperty("SelectionContainer", pattern.SelectionContainer)
                };
                detailGroups.Add(new DetailGroupViewModel("SelectionItem Pattern", patternDetails));
            }
            // SelectionPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.SelectionPattern))
            {
                var pattern = AutomationElement.Patterns.Selection.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("Selection", pattern.Selection),
                    DetailViewModel.FromAutomationProperty("CanSelectMultiple", pattern.CanSelectMultiple),
                    DetailViewModel.FromAutomationProperty("IsSelectionRequired", pattern.IsSelectionRequired)
                };
                detailGroups.Add(new DetailGroupViewModel("Selection Pattern", patternDetails));
            }
            // TableItemPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TableItemPattern))
            {
                var pattern = AutomationElement.Patterns.TableItem.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("ColumnHeaderItems", pattern.ColumnHeaderItems),
                    DetailViewModel.FromAutomationProperty("RowHeaderItems", pattern.RowHeaderItems)
                };
                detailGroups.Add(new DetailGroupViewModel("TableItem Pattern", patternDetails));
            }
            // TablePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TablePattern))
            {
                var pattern = AutomationElement.Patterns.Table.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("ColumnHeaderItems", pattern.ColumnHeaders),
                    DetailViewModel.FromAutomationProperty("RowHeaderItems", pattern.RowHeaders),
                    DetailViewModel.FromAutomationProperty("RowOrColumnMajor", pattern.RowOrColumnMajor)
                };
                detailGroups.Add(new DetailGroupViewModel("Table Pattern", patternDetails));
            }
            // TogglePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.TogglePattern))
            {
                var pattern = AutomationElement.Patterns.Toggle.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("ToggleState", pattern.ToggleState)
                };
                detailGroups.Add(new DetailGroupViewModel("Toggle Pattern", patternDetails));
            }
            // ValuePattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.ValuePattern))
            {
                var pattern = AutomationElement.Patterns.Value.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("IsReadOnly", pattern.IsReadOnly),
                    DetailViewModel.FromAutomationProperty("Value", pattern.Value)
                };
                detailGroups.Add(new DetailGroupViewModel("Value Pattern", patternDetails));
            }
            // WindowPattern
            if (allSupportedPatterns.Contains(AutomationElement.Automation.PatternLibrary.WindowPattern))
            {
                var pattern = AutomationElement.Patterns.Window.Pattern;
                var patternDetails = new List<DetailViewModel>
                {
                    DetailViewModel.FromAutomationProperty("IsModal", pattern.IsModal),
                    DetailViewModel.FromAutomationProperty("IsTopmost", pattern.IsTopmost),
                    DetailViewModel.FromAutomationProperty("CanMinimize", pattern.CanMinimize),
                    DetailViewModel.FromAutomationProperty("CanMaximize", pattern.CanMaximize),
                    DetailViewModel.FromAutomationProperty("WindowVisualState", pattern.WindowVisualState),
                    DetailViewModel.FromAutomationProperty("WindowInteractionState", pattern.WindowInteractionState)
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
