#if NETFRAMEWORK || NETCOREAPP
using System.Windows.Forms;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Overlay
{
    public class OverlayRectangleForm : Form
    {
        public OverlayRectangleForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            Left = 0;
            Top = 0;
            Width = 1;
            Height = 1;
            Visible = false;
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= (int)WindowStyles.WS_EX_TOOLWINDOW;
                return createParams;
            }
        }
    }
}
#endif
