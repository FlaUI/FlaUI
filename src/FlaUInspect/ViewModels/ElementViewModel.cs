using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUInspect.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace FlaUInspect.ViewModels
{
    public class ElementViewModel : ObservableObject
    {
        private readonly AutomationElement _automationElement;
        private bool _isExpanded;
        private bool _isSelected;

        public ElementViewModel(AutomationElement automationElement)
        {
            _automationElement = automationElement;
            Children = new ObservableCollection<ElementViewModel>();
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
                    // TODO: Show Details
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
            Children.Clear();
            foreach (var child in _automationElement.FindAll(TreeScope.Children, new TrueCondition(), TimeSpan.Zero))
            {
                var childViewModel = new ElementViewModel(child);
                if (loadChild)
                {
                    childViewModel.LoadChildren(false);
                }
                Children.Add(childViewModel);
            }
        }
    }
}
