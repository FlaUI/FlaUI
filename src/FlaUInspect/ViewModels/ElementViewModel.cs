using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUInspect.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;

namespace FlaUInspect.ViewModels
{
    public class ElementViewModel : ObservableObject
    {
        private readonly AutomationElement _automationElement;

        public ElementViewModel(AutomationElement automationElement)
        {
            _automationElement = automationElement;
            var childElements = _automationElement.FindAll(TreeScope.Children, new BoolCondition(true));
            Children = new ObservableCollection<ElementViewModel>(childElements.Select(e => new ElementViewModel(e)));
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
    }
}
