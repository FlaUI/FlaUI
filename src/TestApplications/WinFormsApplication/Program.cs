using System;
using System.Windows.Forms;

namespace WinFormsApplication
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var showComplexControls = Array.IndexOf(args, "--complex-controls") >= 0;
            Application.Run(new Form1(showComplexControls));
        }
    }
}
