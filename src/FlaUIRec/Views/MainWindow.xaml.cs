using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.UIA3;
using Gma.System.MouseKeyHook;

namespace FlaUIRec.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private FlaUI.Core.Application _app;
        private readonly UIA3Automation _automation;
        private readonly IKeyboardMouseEvents _globalHook;

        public MainWindow()
        {
            InitializeComponent();
            ProcessIdText.Text = "12844";
            _automation = new UIA3Automation();

            _globalHook = Hook.GlobalEvents();
            //m_GlobalHook.MouseDownExt += m_GlobalHook_MouseDownExt;
            //m_GlobalHook.MouseMoveExt += m_GlobalHook_MouseMoveExt;
            //m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _globalHook.MouseDownExt -= m_GlobalHook_MouseDownExt;
            _globalHook.MouseMoveExt -= m_GlobalHook_MouseMoveExt;
            _globalHook.KeyPress -= GlobalHookKeyPress;
            _globalHook.Dispose();
            _automation.Dispose();
            base.OnClosing(e);
        }

        private void m_GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            var element = _automation.FromPoint(new FlaUI.Core.Shapes.Point(e.Location.X, e.Location.Y));
            AddToList($"MouseDown ({e.Button}) on {element} ({e.Location})");
        }

        private void m_GlobalHook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            //System.Threading.Thread.Sleep(500);
            AddToList($"MouseMove to {e.Location}");
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            AddToList($"KeyPress: \t{e.KeyChar}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var processId = Convert.ToInt32(ProcessIdText.Text);
            _app = new FlaUI.Core.Application(processId);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _automation.UnregisterAllEvents();
            var mainWindow = _app.GetMainWindow(_automation);
            //mainWindow.RegisterEvent(InvokePattern.InvokedEvent, TreeScope.Descendants, InvokeAction);
            //mainWindow.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, TreeScope.Descendants, SelectionAction);
            //mainWindow.RegisterEvent(TextPattern.TextChangedEvent, TreeScope.Descendants, TextChangedAction);
            //mainWindow.RegisterStructureChangedEvent(TreeScope.Descendants, StructureAction);
            //mainWindow.RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, TogglePattern.ToggleStateProperty);
            //mainWindow.RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, ValuePattern.ValueProperty);

            // Legacy
            //mainWindow.GetUIA2().RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, TogglePattern.ToggleStateProperty);
        }

        private void TextChangedAction(AutomationElement automationAutomationElement, EventId eventId)
        {
            var valuePattern = automationAutomationElement.Patterns.Value.Pattern;
            AddToList($"Text changed on {ElementToString(automationAutomationElement)}: To {valuePattern.Value}");
        }

        private void SelectionAction(AutomationElement automationAutomationElement, EventId eventId)
        {
            AddToList($"Selected: {ElementToString(automationAutomationElement)}");
        }

        private void StructureAction(AutomationElement automationAutomationElement, StructureChangeType arg2, int[] arg3)
        {
            AddToList($"Structure change on {ElementToString(automationAutomationElement)}: {arg2}");
        }

        private void PropertyAction(AutomationElement automationAutomationElement, PropertyId propertyId, object arg3)
        {
            AddToList($"Property change on {ElementToString(automationAutomationElement)}: {propertyId.Name} to {arg3}");
        }

        private void InvokeAction(AutomationElement automationAutomationElement, EventId eventId)
        {
            AddToList($"Invoked: {ElementToString(automationAutomationElement)}");
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

        private string ElementToString(AutomationElement automationElement)
        {
            throw new NotImplementedException();
            //return String.Format("{0} (#{1}) [{2}]", automationElement.Current.Name, automationElement.Current.AutomationId, automationElement.Current.ControlType);
        }
    }
}
