using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using FlaUI.Core.Logging;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Object which is returned when the screen or parts of the screen are captured with <see cref="Capture"/>.
    /// </summary>
    public partial class CaptureImage : IDisposable
    {
        /// <summary>
        /// Creates a <see cref="CaptureImage"/> object with the given <see cref="Bitmap"/>.
        /// </summary>
        public CaptureImage(Bitmap bitmap, Rectangle originalBounds, CaptureSettings settings)
        {
            Bitmap = bitmap;
            OriginalBounds = originalBounds;
            Settings = settings;
            OnInitialized();
        }

        partial void OnInitialized();

        /// <summary>
        /// The original <see cref="Bitmap"/>.
        /// </summary>
        public Bitmap Bitmap { get; }

        /// <summary>
        /// The original bounding rectangle (relative to the whole desktop) that this image is based on.
        /// </summary>
        public Rectangle OriginalBounds { get; }

        /// <summary>
        /// The <see cref="CaptureSettings"/> used to capture the image.
        /// </summary>
        public CaptureSettings Settings { get; }

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

        /// <inheritdoc />
        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
