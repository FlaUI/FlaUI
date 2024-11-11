﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using FlaUI.Core.Tools;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Contains extension methods for <see cref="AutomationElement"/>s.
    /// </summary>
    public static partial class AutomationElementExtensions
    {
        /// <summary>
        /// Draws a red highlight around the element.
        /// </summary>
        /// <param name="self">The element to highlight.</param>
        public static T DrawHighlight<T>(this T self) where T : AutomationElement
        {
            return DrawHighlight(self, Color.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        /// <param name="self">The element to highlight.</param>
        /// <param name="color">The color to draw the highlight.</param>
        public static T DrawHighlight<T>(this T self, Color color) where T : AutomationElement
        {
            return DrawHighlight(self, true, color);
        }

        /// <summary>
        /// Draw a highlight around the element with the given settings.
        /// </summary>
        /// <param name="self">The element to highlight.</param>
        /// <param name="blocking">Flag to indicate if further execution waits until the highlight is removed.</param>
        /// <param name="color">The color to draw the highlight.</param>
        /// <param name="duration">The duration how long the highlight is shown.</param>
        public static T DrawHighlight<T>(this T self, bool blocking, Color color, TimeSpan? duration = null) where T : AutomationElement
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
        [return: NotNullIfNotNull(nameof(self))]
        public static T? WaitUntilClickable<T>(this T? self, TimeSpan? timeout = null) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.WhileFalse(() => self.TryGetClickablePoint(out var _), timeout: timeout, throwOnTimeout: true, ignoreException: true);
            }
            return self;
        }

        /// <summary>
        /// Waits until the element is enabled.
        /// </summary>
        [return: NotNullIfNotNull(nameof(self))]
        public static T? WaitUntilEnabled<T>(this T? self, TimeSpan? timeout = null) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.WhileFalse(() => self.IsEnabled, timeout: timeout, throwOnTimeout: true, ignoreException: true);
            }
            return self;
        }
    }
}
