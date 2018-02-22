using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;

namespace FlaUI.Core.Capturing
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
        public CaptureImage(Bitmap bitmap, Rectangle desktopBounds)
        {
            Bitmap = bitmap;
            DesktopBounds = desktopBounds;
            _bitmapImageLazy = new Lazy<BitmapImage>(ToWpf);
        }

        /// <summary>
        /// The original <see cref="Bitmap"/>.
        /// </summary>
        public Bitmap Bitmap { get; private set; }

        /// <summary>
        /// The bounding rectangle on the desktop that this image is based on.
        /// </summary>
        public Rectangle DesktopBounds { get; }

        /// <summary>
        /// A WPF friendly <see cref="BitmapImage"/> of the <see cref="Bitmap"/>.
        /// </summary>
        public BitmapImage BitmapImage => _bitmapImageLazy.Value;

        /// <summary>
        /// Saves the image to the file with the given path.
        /// Uses the file extension as format, defaults to <see cref="ImageFormat.Png"/>.
        /// </summary>
        public void ToFile(string filePath)
        {
            var imageFormat = ImageFormat.Png;
            var ext = Path.GetExtension(filePath)?.ToLower();
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
        /// Applies all the given overlays onto the image.
        /// </summary>
        public CaptureImage ApplyOverlays(params ICaptureOverlay[] overlays)
        {
            if (overlays.Any())
            {
                using (var g = Graphics.FromImage(Bitmap))
                {
                    foreach (var overlay in overlays)
                    {
                        try
                        {
                            overlay.Draw(g);
                        }
                        catch (Exception ex)
                        {
                            Logger.Default.Error($"Failed applying overlay '{overlay.GetType().FullName}'", ex);
                        }
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// Resizes the image by a given percent.
        /// </summary>
        /// <param name="percent">The percent of the new size (1 = 100%).</param>
        public CaptureImage ResizeByPercent(double percent)
        {
            var newWidth = (Bitmap.Width * percent).ToInt();
            var newHeight = (Bitmap.Height * percent).ToInt();
            return ResizeBySize(newWidth, newHeight);
        }

        /// <summary>
        /// Resize the image to the given size.
        /// </summary>
        /// <param name="newWidth">The new width, can be -1 if it should be adjusted automatically to a given height.</param>
        /// <param name="newHeight">The new height, can be -1 if it should be adjusted automatically to a given width.</param>
        public CaptureImage ResizeBySize(int newWidth, int newHeight)
        {
            // Fix width/height in case only one size is given
            if (newHeight == -1)
            {
                var percent = newWidth / (double)Bitmap.Width;
                newHeight = (Bitmap.Height * percent).ToInt();
            }
            else if (newWidth == -1)
            {
                var percent = newHeight / (double)Bitmap.Height;
                newWidth = (Bitmap.Width * percent).ToInt();
            }

            // Code taken from https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
            var destImage = new Bitmap(newWidth, newHeight);
            // Maintain the original DPI
            destImage.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
            using (var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Used to prevent ghosting around image borders with transparent pixels
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(Bitmap, new Rectangle(0, 0, newWidth, newHeight), 0, 0, Bitmap.Width, Bitmap.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            Bitmap = null;
            Bitmap = destImage;
            return this;
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

        /// <inheritdoc />
        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
