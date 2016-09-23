using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUInspect.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FlaUInspect.ViewModels
{
    public class ElementViewModel : ObservableObject
    {
        private readonly Element _element;

        public ElementViewModel(Element element)
        {
            _element = element;
            var childElements = _element.FindAll(TreeScope.Children, new BoolCondition(true));
            Children = new ObservableCollection<ElementViewModel>(childElements.Select(e => new ElementViewModel(e)));
        }

        public string Name { get { return NormalizeString(_element.Current.Name); } }
        public string AutomationId { get { return NormalizeString(_element.Current.AutomationId); } }
        public ControlType ControlType { get { return _element.Current.ControlType; } }
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
