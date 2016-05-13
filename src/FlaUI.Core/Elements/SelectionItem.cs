using FlaUI.Core.Exceptions;
using FlaUI.Core.Patterns;
using System;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Elements
{
    /// <summary>
    /// An UI-item which supports the <see cref="SelectionItemPattern"/>
    /// </summary>
    public class SelectionItem : AutomationElement
    {
        public SelectionItem(Automation automation, UIA.IUIAutomationElement nativeElement) : base(automation, nativeElement) { }

        public SelectionItemPattern SelectionItemPattern
        {
            get { return PatternFactory.GetSelectionItemPattern(); }
        }

        public bool IsSelected
        {
            get { return SelectionItemPattern.Current.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        public void Select()
        {
            var selectionItemPattern = SelectionItemPattern;
            if (selectionItemPattern == null)
            {
                throw new MethodNotSupportedException(String.Format("Select on '{0}' is not supported", ToString()));
            }
            selectionItemPattern.Select();
        }
    }
}
