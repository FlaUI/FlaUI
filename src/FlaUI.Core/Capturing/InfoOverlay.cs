using System;
using System.Drawing;
using System.Text.RegularExpressions;
using FlaUI.Core.Tools;

namespace FlaUI.Core.Capturing
{
    /// <summary>
    /// Overlay with various information about the system.
    /// </summary>
    public class InfoOverlay : OverlayBase
    {
        public InfoOverlay(Rectangle desktopBounds) : base(desktopBounds)
        {
        }

        /// <summary>
        /// The string to use for the overlay. Has some variables which are automatically replaced.
        /// The variables are:
        /// - dt: The current systems datetime, can additionally be followed with a .net format string.
        /// - ct: The custom timespan set on this overlay (<see cref="CustomTimeSpan"/>).
        /// - name: The machine name of the current system.
        /// - cpu: The cpu usage.
        /// - mem.p.tot: The physical total memory.
        /// - mem.p.free: The physical free memory.
        /// - mem.p.used: The physical used memory.
        /// - mem.p.free.perc: The physical free memory in percent.
        /// - mem.p.used.perc: The physical used memory in percent.
        /// - mem.v.tot: The virtual total memory.
        /// - mem.v.free: The virtual free memory.
        /// - mem.v.used: The virtual used memory.
        /// - mem.v.free.perc: The virtual free memory in percent.
        /// - mem.v.used.perc: The virtual used memory in percent.
        /// </summary>
        public string OverlayStringFormat { get; set; } = "{dt:yyyy-MM-dd HH:mm:ss.fff} / {name} / CPU: {cpu} / RAM: {mem.p.used}/{mem.p.tot} ({mem.p.used.perc})";

        /// <summary>
        /// The position of the overlay.
        /// </summary>
        public InfoOverlayPosition OverlayPosition { get; set; } = InfoOverlayPosition.TopLeft;

        /// <summary>
        /// The color of the overlay background (can also have an alpha for semi transparent).
        /// </summary>
        public Color OverlayBackgroundColor { get; set; } = Color.FromArgb(100, Color.Black);

        /// <summary>
        /// The color of the overlay text.
        /// </summary>
        public Color OverlayTextColor { get; set; } = Color.White;

        /// <summary>
        /// A custom timespan (for example for the recording duration).
        /// </summary>
        public TimeSpan CustomTimeSpan { get; set; } = TimeSpan.Zero;

        public override void Draw(Graphics g)
        {
            const int textOffsetToBg = 2;
            var overlayString = FormatOverlayString(OverlayStringFormat);
            var font = new Font("Consolas", 10f);
            var bgBrush = new SolidBrush(OverlayBackgroundColor);
            var fontBrush = new SolidBrush(OverlayTextColor);
            var textSize = g.MeasureString(overlayString, font);
            // Calculate background size and position
            var bgHeight = textSize.Height + 2 * textOffsetToBg;
            var bgWidth = DesktopBounds.Width;
            var bgPosX = 0;
            var bgPosY = IsPositionTop() ? 0 : DesktopBounds.Height - bgHeight;
            // Calculate text position
            var textPosY = bgPosY + textOffsetToBg;
            float textPosX = textOffsetToBg;
            if (IsPositionRight())
            {
                textPosX = bgWidth - textSize.Width - textOffsetToBg;
            }
            else if (IsPositionCenter())
            {
                textPosX = bgWidth / 2 - textSize.Width / 2 - textOffsetToBg / 2;
            }
            // Draw the background
            g.FillRectangle(bgBrush, bgPosX, bgPosY, bgWidth, bgHeight);
            // Draw the text
            g.DrawString(overlayString, font, fontBrush, textPosX, textPosY);
        }

        private string FormatOverlayString(string overlayString)
        {
            SystemInfo.RefreshAll();
            // Replace the simple values
            overlayString = overlayString
                .Replace("{name}", $"{Environment.MachineName}")
                .Replace("{cpu}", $"{SystemInfo.CpuUsage,5:##.00}%")
                .Replace("{mem.p.tot}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryTotal, 2),7}")
                .Replace("{mem.p.free}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryFree, 2),7}")
                .Replace("{mem.p.used}", $"{StringFormatter.SizeSuffix(SystemInfo.PhysicalMemoryUsed, 2),7}")
                .Replace("{mem.p.free.perc}", $"{SystemInfo.PhysicalMemoryFreePercent,5:##.00}%")
                .Replace("{mem.p.used.perc}", $"{SystemInfo.PhysicalMemoryUsedPercent,5:##.00}%")
                .Replace("{mem.v.tot}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryTotal, 2),7}")
                .Replace("{mem.v.free}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryFree, 2),7}")
                .Replace("{mem.v.used}", $"{StringFormatter.SizeSuffix(SystemInfo.VirtualMemoryUsed, 2),7}")
                .Replace("{mem.v.free.perc}", $"{SystemInfo.VirtualMemoryFreePercent,5:##.00}%")
                .Replace("{mem.v.used.perc}", $"{SystemInfo.VirtualMemoryUsedPercent,5:##.00}%");

            // Replace the date/time
            var now = DateTime.Now;
            overlayString = Regex.Replace(overlayString, @"\{dt:?(.*?)\}", m => now.ToString(m.Groups[1].Value));

            // Replace the custom timespan
            overlayString = Regex.Replace(overlayString, @"\{ct:?(.*?)\}", m => CustomTimeSpan.ToString(m.Groups[1].Value));

            return overlayString;
        }

        private bool IsPositionTop()
        {
            return OverlayPosition.ToString().StartsWith("Top");
        }

        private bool IsPositionCenter()
        {
            return OverlayPosition.ToString().EndsWith("Center");
        }

        private bool IsPositionRight()
        {
            return OverlayPosition.ToString().EndsWith("Right");
        }
    }
}
