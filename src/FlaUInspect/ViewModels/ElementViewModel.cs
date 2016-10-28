using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
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
            ItemDetails = new ExtendedObservableCollection<DetailViewModel>();
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
        public ExtendedObservableCollection<DetailViewModel> ItemDetails { get; set; }

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

        private List<DetailViewModel> LoadDetails()
        {
            var details = new List<DetailViewModel>();
            // Element details
            details.Add(new DetailViewModel("AutomationId", AutomationElement.Current.AutomationId));
            details.Add(new DetailViewModel("Name", AutomationElement.Current.Name));
            details.Add(new DetailViewModel("ClassName", AutomationElement.Current.ClassName));
            details.Add(new DetailViewModel("ControlType", AutomationElement.Current.ControlType));
            details.Add(new DetailViewModel("LocalizedControlType", AutomationElement.Current.LocalizedControlType));
            details.Add(new DetailViewModel("FrameworkType", AutomationElement.FrameworkType));
            details.Add(new DetailViewModel("FrameworkId", AutomationElement.Current.FrameworkId));
            details.Add(new DetailViewModel("ProcessId", AutomationElement.Current.ProcessId));
            details.Add(new DetailViewModel("BoundingRectangle", AutomationElement.Current.BoundingRectangle));
            // Pattern details
            var allSupportedPatterns = AutomationElement.BasicAutomationElement.GetSupportedPatterns();
            var allPatterns = AutomationElement.Automation.PatternLibrary.AllSupportedPatterns;
            foreach (var pattern in allPatterns)
            {
                details.Add(new DetailViewModel(pattern.Name + "Pattern", allSupportedPatterns.Contains(pattern) ? "Yes" : "No"));
            }
            return details;
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
