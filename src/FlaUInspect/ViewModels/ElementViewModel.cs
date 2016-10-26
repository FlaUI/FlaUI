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
        private readonly AutomationElement _automationElement;
        private bool _isExpanded;
        private bool _isSelected;

        public event Action<ElementViewModel> SelectionChanged;

        public ElementViewModel(AutomationElement automationElement)
        {
            _automationElement = automationElement;
            Children = new ObservableCollection<ElementViewModel>();
            ItemDetails = new ObservableCollection<DetailViewModel>();
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (value)
                {
                    _automationElement.DrawHighlight(false, Colors.Red, 1000);
                    ItemDetails.Clear();
                    ItemDetails.Add(new DetailViewModel("AutomationId", _automationElement.Current.AutomationId));
                    ItemDetails.Add(new DetailViewModel("Name", _automationElement.Current.Name));
                    ItemDetails.Add(new DetailViewModel("ClassName", _automationElement.Current.ClassName));
                    ItemDetails.Add(new DetailViewModel("ControlType", _automationElement.Current.ControlType));
                    ItemDetails.Add(new DetailViewModel("LocalizedControlType", _automationElement.Current.LocalizedControlType));
                    ItemDetails.Add(new DetailViewModel("FrameworkType", _automationElement.FrameworkType));
                    ItemDetails.Add(new DetailViewModel("FrameworkId", _automationElement.Current.FrameworkId));
                    ItemDetails.Add(new DetailViewModel("ProcessId", _automationElement.Current.ProcessId));
                    ItemDetails.Add(new DetailViewModel("BoundingRectangle", _automationElement.Current.BoundingRectangle));

                    var allPatterns = _automationElement.Automation.PatternLibrary.AllSupportedPatterns;
                    var allElementPatterns = _automationElement.BasicAutomationElement.GetSupportedPatterns();
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
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                if (value)
                {
                    LoadChildren(true);
                }
            }
        }

        public string Name => NormalizeString(_automationElement.Current.Name);
        public string AutomationId => NormalizeString(_automationElement.Current.AutomationId);
        public ControlType ControlType => _automationElement.Current.ControlType;
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
            foreach (var child in _automationElement.FindAll(TreeScope.Children, new TrueCondition(), TimeSpan.Zero))
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
