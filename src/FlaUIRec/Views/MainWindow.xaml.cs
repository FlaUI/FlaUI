using FlaUI.UIA3;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Identifiers;
using FlaUI.UIA3.Patterns;
using FlaUI.UIA3.Tools;
using Gma.System.MouseKeyHook;
using System;
using System.Windows;
using System.Windows.Forms;
using Window = System.Windows.Window;

namespace FlaUIRec.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlaUI.Core.Application _app;
        private IKeyboardMouseEvents m_GlobalHook;

        public MainWindow()
        {
            InitializeComponent();
            ProcessIdText.Text = "12844";

            m_GlobalHook = Hook.GlobalEvents();
            //m_GlobalHook.MouseDownExt += m_GlobalHook_MouseDownExt;
            //m_GlobalHook.MouseMoveExt += m_GlobalHook_MouseMoveExt;
            //m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            m_GlobalHook.MouseDownExt -= m_GlobalHook_MouseDownExt;
            m_GlobalHook.MouseMoveExt -= m_GlobalHook_MouseMoveExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;
            m_GlobalHook.Dispose();
            base.OnClosing(e);
        }

        private void m_GlobalHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            var automation = new Automation();
            var element = automation.FromPoint(new FlaUI.Core.Shapes.Point(e.Location.X, e.Location.Y));
            AddToList(String.Format("MouseDown ({0}) on {1} ({2})", e.Button, element, e.Location));
        }

        private void m_GlobalHook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            //System.Threading.Thread.Sleep(500);
            AddToList(String.Format("MouseMove to {0}", e.Location));
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            AddToList(String.Format("KeyPress: \t{0}", e.KeyChar));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var processId = Convert.ToInt32(ProcessIdText.Text);
            _app = new FlaUI.Core.Application(processId);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            var automation = new Automation();
            automation.UnregisterAllEvents();
            var mainWindow = _app.GetMainWindow(automation);
            mainWindow.RegisterEvent(InvokePattern.InvokedEvent, TreeScope.Descendants, InvokeAction);
            mainWindow.RegisterEvent(SelectionItemPattern.ElementSelectedEvent, TreeScope.Descendants, SelectionAction);
            mainWindow.RegisterEvent(TextPattern.TextChangedEvent, TreeScope.Descendants, TextChangedAction);
            mainWindow.RegisterStructureChangedEvent(TreeScope.Descendants, StructureAction);
            mainWindow.RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, TogglePattern.ToggleStateProperty);
            mainWindow.RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, ValuePattern.ValueProperty);

            // Legacy
            //mainWindow.GetUIA2().RegisterPropertyChangedEvent(TreeScope.Descendants, PropertyAction, TogglePattern.ToggleStateProperty);
        }

        private void TextChangedAction(AutomationElement automationElement, EventId eventId)
        {
            var valuePattern = automationElement.PatternFactory.GetValuePattern();
            AddToList(String.Format("Text changed on {0}: To {1}", ElementToString(automationElement), valuePattern.Current.Value));
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
