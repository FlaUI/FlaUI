using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using FlaUI.Core.Logging;
using FlaUI.Core.Tools;

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
        public CaptureImage(Bitmap bitmap)
        {
            Bitmap = bitmap;
            _bitmapImageLazy = new Lazy<BitmapImage>(ToWpf);
        }

        /// <summary>
        /// The original <see cref="Bitmap"/>.
        /// </summary>
        public Bitmap Bitmap { get; }

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

        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
