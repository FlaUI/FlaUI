using System;
using System.Windows.Media;
using FlaUI.Core.Tools;
using GdiColor = System.Drawing.Color;
using WpfColor = System.Windows.Media.Color;

namespace FlaUI.Core.AutomationElements.Infrastructure
{
    public static partial class AutomationElementExtensions
    {
        /// <summary>
        /// Draws a red highlight around the element.
        /// </summary>
        public static T DrawHighlight<T>(this T self) where T : AutomationElement
        {
            return DrawHighlight(self, Colors.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        public static T DrawHighlight<T>(this T self, WpfColor color) where T : AutomationElement
        {
            return DrawHighlight(self, true, color);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        public static T DrawHighlight<T>(this T self, GdiColor color) where T : AutomationElement
        {
            return DrawHighlight(self, true, color);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings.
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed.</param>
        /// <param name="color">The color to draw the highlight.</param>
        /// <param name="duration">The duration how long the highlight is shown.</param>
        /// <remarks>Override for winforms color.</remarks>
        public static T DrawHighlight<T>(this T self, bool blocking, GdiColor color, TimeSpan? duration = null) where T : AutomationElement
        {
            return DrawHighlight(self, blocking, WpfColor.FromArgb(color.A, color.R, color.G, color.B), duration);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings.
        /// </summary>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed.</param>
        /// <param name="color">The color to draw the highlight.</param>
        /// <param name="duration">The duration how long the highlight is shown.</param>
        public static T DrawHighlight<T>(this T self, bool blocking, WpfColor color, TimeSpan? duration = null) where T : AutomationElement
        {
            var rectangle = self.Properties.BoundingRectangle.Value;
            if (!rectangle.IsEmpty)
            {
                var durationInMs = (int)(duration ?? TimeSpan.FromSeconds(2)).TotalMilliseconds;
                if (blocking)
                {
                    self.Automation.OverlayManager.ShowBlocking(rectangle, color, durationInMs);
                }
                else
                {
                    self.Automation.OverlayManager.Show(rectangle, color, durationInMs);
                }
            }
            return self;
        }

        /// <summary>
        /// Waits until the element has a clickable point.
        /// </summary>
        public static T WaitForClickablePoint<T>(this T self) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.While(() => self.TryGetClickablePoint(out var _) == false);
            }
            return self;
        }
    }
}
