using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
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
            Children = new ObservableCollection<ElementViewModel>();
            ItemDetails = new ObservableCollection<DetailViewModel>();
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
                    AutomationElement.DrawHighlight(false, Colors.Red, 1000);
                    ItemDetails.Clear();
                    ItemDetails.Add(new DetailViewModel("AutomationId", AutomationElement.Current.AutomationId));
                    ItemDetails.Add(new DetailViewModel("Name", AutomationElement.Current.Name));
                    ItemDetails.Add(new DetailViewModel("ClassName", AutomationElement.Current.ClassName));
                    ItemDetails.Add(new DetailViewModel("ControlType", AutomationElement.Current.ControlType));
                    ItemDetails.Add(new DetailViewModel("LocalizedControlType", AutomationElement.Current.LocalizedControlType));
                    ItemDetails.Add(new DetailViewModel("FrameworkType", AutomationElement.FrameworkType));
                    ItemDetails.Add(new DetailViewModel("FrameworkId", AutomationElement.Current.FrameworkId));
                    ItemDetails.Add(new DetailViewModel("ProcessId", AutomationElement.Current.ProcessId));
                    ItemDetails.Add(new DetailViewModel("BoundingRectangle", AutomationElement.Current.BoundingRectangle));

                    var allPatterns = AutomationElement.Automation.PatternLibrary.AllSupportedPatterns;
                    var allElementPatterns = AutomationElement.BasicAutomationElement.GetSupportedPatterns();
                    foreach (var pattern in allPatterns)
                    {
                        ItemDetails.Add(new DetailViewModel(pattern.Name + "Pattern", allElementPatterns.Contains(pattern) ? "yes" : "no"));
                    }

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
        public ObservableCollection<ElementViewModel> Children { get; set; }
        public ObservableCollection<DetailViewModel> ItemDetails { get; set; }

        private string NormalizeString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Replace(Environment.NewLine, " ").Replace('\r', ' ').Replace('\n', ' ');
        }

        public void LoadChildren(bool loadChild)
        {
            foreach (var child in Children)
            {
                child.SelectionChanged -= SelectionChanged;
            }
            Children.Clear();
            foreach (var child in AutomationElement.FindAll(TreeScope.Children, new TrueCondition(), TimeSpan.Zero))
            {
                var childViewModel = new ElementViewModel(child);
                childViewModel.SelectionChanged += SelectionChanged;
                if (loadChild)
                {
                    childViewModel.LoadChildren(false);
                }
                Children.Add(childViewModel);
            }
        }
    }
}
