using System;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Provides methods to compare element screenshot with an image saved in a file.
    /// </summary>
    public static class ImageAssert
    {
        /// <summary>
        /// Compares the automation element with the image from specified file path.
        /// If the snapshot of the automation element differs from the image in the file then an exception is thrown.
        /// When you create the image file specified as the parameter (using FlaUInspect tool), make sure the element you are taking a snapshot of is entirely visible on the screen and it is not (partially or completely) overlapped by another window.
        /// Also, when calling this method make sure the element is entirely visible on screen.
        /// </summary>
        /// <param name="element">The automation element being compared.</param>
        /// <param name="filePath">The filepath of file containing the image.</param>
        public static void AreEqual(AutomationElement element, string filePath)
        {
            var progManager = element.Automation.GetDesktop().FindFirstChild(cf => cf.ByControlType(ControlType.Pane).And(cf.ByName("Program Manager")));
            if (progManager != null)
            {
                var desktopList = progManager.FindFirstChild(cf => cf.ByControlType(ControlType.List).And(cf.ByName("Desktop")));
                if (desktopList != null)
                {
                    // Set focus on desktop so the tested application will lose the focus.
                    // We want to capture the element without focus. 
                    // Controls and windows look different when they have the focus (on edit control a caret may appear, text may be selected and so on).
                    desktopList.FrameworkAutomationElement.SetFocus();
                    System.Threading.Thread.Sleep(300);
                }
            }
            
            Bitmap crtBitmap = element.Capture();
            
            // restore focus on the automation element
            element.FrameworkAutomationElement.SetFocus();
            
            Bitmap bitmapFromFile = null;
            try
            {
                bitmapFromFile = new Bitmap(filePath);
            }
            catch (Exception ex)
            {
                crtBitmap.Dispose();
                throw ex;
            }
            
            //compare...
            if (crtBitmap.Height != bitmapFromFile.Height || crtBitmap.Width != bitmapFromFile.Width)
            {
                throw new Exception("Images have different sizes");
            }
            
            bool identic = true;
            for (int i = 0; i < crtBitmap.Width; i++)
            {
                for (int j = 0; j < crtBitmap.Height; j++)
                {
                    Color pixel1 = crtBitmap.GetPixel(i, j);
                    Color pixel2 = bitmapFromFile.GetPixel(i, j);
                    
                    if (pixel1.ToArgb() != pixel2.ToArgb())
                    {
                        identic = false;
                        break;
                    }
                }
            }
            
            crtBitmap.Dispose();
            bitmapFromFile.Dispose();
            
            if (identic == false)
            {
                throw new Exception("Images differ");
            }
        }
    }
}
