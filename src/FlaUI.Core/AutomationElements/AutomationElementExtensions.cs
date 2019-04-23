using System;
using System.Drawing;
using FlaUI.Core.Input;
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
        public static T DrawHighlight<T>(this T self) where T : AutomationElement
        {
            return DrawHighlight(self, Color.Red);
        }

        /// <summary>
        /// Draws a manually colored highlight around the element.
        /// </summary>
        public static T DrawHighlight<T>(this T self, Color color) where T : AutomationElement
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
        public static T WaitUntilClickable<T>(this T self, TimeSpan? timeout = null) where T : AutomationElement
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
        public static T WaitUntilEnabled<T>(this T self, TimeSpan? timeout = null) where T : AutomationElement
        {
            if (self != null)
            {
                Retry.WhileFalse(() => self.IsEnabled, timeout: timeout, throwOnTimeout: true, ignoreException: true);
            }
            return self;
        }

        /// <summary>
        /// Clicks in chosen element, creates instance of target object and returns it.
        /// </summary>
        /// <typeparam name="T">Type of target object to create.</typeparam>
        public static T Click<T>(this AutomationElement element, TimeSpan? timeout = null, TimeSpan? interval = null) where T : AutomationElement
        {
            Retry.WhileException(() =>
                {
                    element.Click();
                },
                timeout,
                interval,
                true);

            var type = typeof(T);
            var ctorAutomationElement = type.GetConstructor(new[] { typeof(AutomationElement) });

            return Retry.WhileNull(
                    () => (T)ctorAutomationElement?.Invoke(new object[] { element }),
                    timeout,
                    interval,
                    true,
                    true)
                .Result;
        }
    }
}
