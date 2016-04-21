using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlaUI.Core.Drawing
{
    public class ScreenRectangle
    {
        private readonly Form _form = new Form();

        public ScreenRectangle(Color color, Rectangle rectangle)
        {
            _form.FormBorderStyle = FormBorderStyle.None;
            _form.ShowInTaskbar = false;
            _form.TopMost = true;
            _form.Left = 0;
            _form.Top = 0;
            _form.Width = 1;
            _form.Height = 1;
            _form.BackColor = color;
            _form.Opacity = 0.8;
            _form.Visible = false;

            // Set popup style
            var num1 = WindowsAPI.NativeWindow.GetWindowLong(_form.Handle, -20);
            WindowsAPI.NativeWindow.SetWindowLong(_form.Handle, -20, num1 | 0x80);

            // Set position
            WindowsAPI.NativeWindow.SetWindowPos(_form.Handle, new IntPtr(-1),
                Convert.ToInt32(rectangle.X), Convert.ToInt32(rectangle.Y),
                Convert.ToInt32(rectangle.Width), Convert.ToInt32(rectangle.Height), 0x10);
        }

        public virtual void Show()
        {
            WindowsAPI.NativeWindow.ShowWindow(_form.Handle, 8);
        }

        public virtual void Hide()
        {
            _form.Hide();
            _form.Dispose();
        }
    }
}
