
namespace Inspector
{
    public partial class MainForm : Form
    {
        private OverlayForm? overlay;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartSelection_Click(object sender, EventArgs e)
        {
            overlay = new OverlayForm();
            overlay.ElementSelected += Overlay_ElementSelected;
            overlay.Show();
            overlay.BeginCapture();
        }

        private void Overlay_ElementSelected(object? sender, AutomationElementSelectedEventArgs e)
        {
            overlay?.Close();
            overlay = null;

            var element = e.Element;
            string info = $"Name: {element.Name}\n" +
                          $"ControlType: {element.ControlType}\n" +
                          $"AutomationId: {element.AutomationId}\n" +
                          $"BoundingRectangle: {element.BoundingRectangle}";

            MessageBox.Show(info, "UI Element Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
