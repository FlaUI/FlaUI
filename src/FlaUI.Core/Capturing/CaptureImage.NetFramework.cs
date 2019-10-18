#if NETFRAMEWORK
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace FlaUI.Core.Capturing
{
    public partial class CaptureImage
    {
        private Lazy<BitmapImage> _bitmapImageLazy;

        /// <summary>
        /// A WPF friendly <see cref="BitmapImage"/> of the <see cref="Bitmap"/>.
        /// </summary>
        public BitmapImage BitmapImage => _bitmapImageLazy.Value;

        partial void OnInitialized()
        {
            _bitmapImageLazy = new Lazy<BitmapImage>(ToWpf);
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
    }
}
#endif
