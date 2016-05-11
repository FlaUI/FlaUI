using System;
using System.Windows;
using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using Window = System.Windows.Window;

namespace FlaUIRec.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlaUI.Core.Application _app;
        public MainWindow()
        {
            InitializeComponent();
            ProcessIdText.Text = "12844";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var processId = Convert.ToInt32(ProcessIdText.Text);
            _app = new FlaUI.Core.Application(processId);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _app.Automation.UnregisterAllEvents();
            _app.GetMainWindow().RegisterEvent(InvokePattern.InvokedEvent, TreeScope.Descendants, InvokeAction);
            _app.GetMainWindow().RegisterEvent(SelectionItemPattern.ElementSelectedEvent, TreeScope.Descendants, SelectionAction);
            _app.GetMainWindow().RegisterEvent(TextPattern.TextChangedEvent, TreeScope.Descendants, TextChangedAction);
            _app.GetMainWindow().RegisterStructureChangedEvent(TreeScope.Descendants, StructureAction);
            _app.GetMainWindow().RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, TogglePattern.ToggleStateProperty);
            _app.GetMainWindow().RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, ValuePattern.ValueProperty);
        }

        private void TextChangedAction(AutomationElement automationElement, EventId eventId)
        {
            AddToList(String.Format("Text changed: {0}", ElementToString(automationElement)));
        }

        private void SelectionAction(AutomationElement automationElement, EventId eventId)
        {
            AddToList(String.Format("Selected: {0}", ElementToString(automationElement)));
        }

        private void StructureAction(AutomationElement automationElement, StructureChangeType arg2, int[] arg3)
        {
            AddToList(String.Format("Structure change on {0}: {1}", ElementToString(automationElement), arg2));
        }

        private void PropertyAction(AutomationElement automationElement, PropertyId propertyId, object arg3)
        {
            AddToList(String.Format("Property change on {0}: {1} to {2}", ElementToString(automationElement), propertyId.Name, arg3));
        }

        private void InvokeAction(AutomationElement automationElement, EventId eventId)
        {
            AddToList(String.Format("Invoked: {0}", ElementToString(automationElement)));
        }

        private void AddToList(string msg)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<string>(AddToList), msg);
                return;
            }
            myList.Items.Insert(0, msg);
        }

        private string ElementToString(AutomationElement element)
        {
            return String.Format("{0} (#{1}) [{2}]", element.Current.Name, element.Current.AutomationId, element.Current.ControlType);
        }
    }
}
