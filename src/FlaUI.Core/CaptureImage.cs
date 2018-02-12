using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using Rectangle = FlaUI.Core.Shapes.Rectangle;

namespace FlaUI.Core
{
    /// <summary>
    /// Object which is returned when the screen or parts of the screen are captured with <see cref="Capture"/>.
    /// </summary>
    public class CaptureImage : IDisposable
    {
        private readonly Lazy<BitmapImage> _bitmapImageLazy;

        /// <summary>
        /// Creates a <see cref="CaptureImage"/> object with the given <see cref="Bitmap"/>.
        /// </summary>
        public CaptureImage(Bitmap bitmap, Rectangle originalBounds)
        {
            Bitmap = bitmap;
            OriginalBounds = originalBounds;
            CaptureTime = DateTime.Now;
            _bitmapImageLazy = new Lazy<BitmapImage>(ToWpf);
            // Get the cursor info
            CURSORINFO pci;
            pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));
            if (User32.GetCursorInfo(out pci))
            {
                CursorInfo = pci;
            }
        }

        /// <summary>
        /// The date and time when this image was capture.
        /// </summary>
        public DateTime CaptureTime { get; }

        /// <summary>
        /// The original <see cref="Bitmap"/>.
        /// </summary>
        public Bitmap Bitmap { get; }

        /// <summary>
        /// The original bounds of the rectangle when this image was captured.
        /// </summary>
        public Rectangle OriginalBounds { get; }

        /// <summary>
        /// A WPF friendly <see cref="BitmapImage"/> of the <see cref="Bitmap"/>.
        /// </summary>
        public BitmapImage BitmapImage => _bitmapImageLazy.Value;

        /// <summary>
        /// The state of the cursor when this image was captured.
        /// </summary>
        private CURSORINFO? CursorInfo { get; }

        /// <summary>
        /// Saves the image to the file with the given path.
        /// Uses the file extension as format, defaults to <see cref="ImageFormat.Png"/>.
        /// </summary>
        public void ToFile(string filePath)
        {
            var imageFormat = ImageFormat.Png;
            var ext = Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    imageFormat = ImageFormat.Jpeg;
                    break;
                case ".gif":
                    imageFormat = ImageFormat.Gif;
                    break;
                case ".tif":
                case ".tiff":
                    imageFormat = ImageFormat.Tiff;
                    break;
                case ".bmp":
                    imageFormat = ImageFormat.Bmp;
                    break;
            }
            Logger.Default.Debug($"Saving image to file: {filePath}");
            Bitmap.Save(filePath, imageFormat);
        }

        /// <summary>
        /// Converts a WinForms <see cref="Bitmap"/> to a WPF friendly <see cref="BitmapImage"/>.
        /// </summary>
        private BitmapImage ToWpf()
        {
            using (var memory = new MemoryStream())
            {
                Bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                memory.Seek(0, SeekOrigin.Begin);
                bitmapImage.StreamSource = memory;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }

        public CaptureImage AddTimestamp(string format = "yyyy-MM-dd HH:mm:ss.fff")
        {
            var stampString = string.IsNullOrEmpty(format) ? CaptureTime.ToString() : CaptureTime.ToString(format);
            using (var g = Graphics.FromImage(Bitmap))
            {
                var font = new Font("Arial", 12f);
                var size = g.MeasureString(stampString, font);
                g.FillRectangle(Brushes.Black, 0, 0, size.Width, 20);
                g.DrawString(stampString, font, Brushes.White, 2, 2);
            }
            return this;
        }

        public CaptureImage AddCursor()
        {
            using (var g = Graphics.FromImage(Bitmap))
            {
                if (CursorInfo.HasValue)
                {
                    var cinfo = CursorInfo.Value;
                    if (cinfo.flags == CursorState.CURSOR_SHOWING)
                    {
                        var x = cinfo.ptScreenPos.X + Math.Abs(OriginalBounds.Left.ToInt());
                        var y = cinfo.ptScreenPos.Y + Math.Abs(OriginalBounds.Top.ToInt());
                        User32.DrawIcon(g.GetHdc(), x, y, cinfo.hCursor);
                        g.ReleaseHdc();
                    }
                }
            }
            return this;
        }

        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
