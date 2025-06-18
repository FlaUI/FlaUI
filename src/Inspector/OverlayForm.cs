using FlaUI.Core;
using FlaUI.UIA3;

namespace Inspector
{
    public partial class OverlayForm : Form
    {
        private readonly GlobalMouseHook mouseHook;
        private readonly AutomationBase automation;

        public event EventHandler<AutomationElementSelectedEventArgs>? ElementSelected;

        public OverlayForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            var primaryScreen = Screen.PrimaryScreen;
            this.Bounds = primaryScreen?.Bounds ?? new Rectangle(0, 0, 800, 600);
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            this.Opacity = 0.3;

            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;

            mouseHook = new GlobalMouseHook();
            automation = new UIA3Automation();
        }

        public void BeginCapture()
        {
            mouseHook.RightClick += MouseHook_RightClick;
            mouseHook.Start();
        }

        private void MouseHook_RightClick(object? sender, Point location)
        {
            var element = automation.FromPoint(location);
            ElementSelected?.Invoke(this, new AutomationElementSelectedEventArgs(element));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            mouseHook.Stop();
            mouseHook.RightClick -= MouseHook_RightClick;
            automation.Dispose();
            base.OnFormClosed(e);
        }
    }
}