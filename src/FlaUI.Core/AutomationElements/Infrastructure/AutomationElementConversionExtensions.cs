namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public static class AutomationElementConversionExtensions
    {
        public static Button AsButton(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Button(automationElement.BasicAutomationElement);
        }

        public static CheckBox AsCheckBox(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new CheckBox(automationElement.BasicAutomationElement);
        }

        public static ComboBox AsComboBox(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new ComboBox(automationElement.BasicAutomationElement);
        }

        public static Label AsLabel(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Label(automationElement.BasicAutomationElement);
        }

        public static ListView AsListView(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new ListView(automationElement.BasicAutomationElement);
        }

        public static Menu AsMenu(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Menu(automationElement.BasicAutomationElement);
        }

        public static MenuItem AsMenuItem(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new MenuItem(automationElement.BasicAutomationElement);
        }

        public static ProgressBar AsProgressBar(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new ProgressBar(automationElement.BasicAutomationElement);
        }

        public static RadioButton AsRadioButton(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new RadioButton(automationElement.BasicAutomationElement);
        }

        public static Slider AsSlider(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Slider(automationElement.BasicAutomationElement);
        }

        public static Tab AsTab(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Tab(automationElement.BasicAutomationElement);
        }

        public static TabItem AsTabItem(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new TabItem(automationElement.BasicAutomationElement);
        }

        public static TextBox AsTextBox(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new TextBox(automationElement.BasicAutomationElement);
        }

        public static Thumb AsThumb(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Thumb(automationElement.BasicAutomationElement);
        }

        public static TitleBar AsTitleBar(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new TitleBar(automationElement.BasicAutomationElement);
        }

        public static Tree AsTree(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Tree(automationElement.BasicAutomationElement);
        }

        public static TreeItem AsTreeItem(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new TreeItem(automationElement.BasicAutomationElement);
        }

        public static Window AsWindow(this AutomationElement automationElement)
        {
            if (automationElement == null)
            {
                return null;
            }
            return new Window(automationElement.BasicAutomationElement);
        }
    }
}
