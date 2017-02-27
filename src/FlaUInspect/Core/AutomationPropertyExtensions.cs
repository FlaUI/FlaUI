using System;
using FlaUI.Core;

namespace FlaUInspect.Core
{
    public static class AutomationPropertyExtensions
    {
        public static string ToDisplayText<T>(this IAutomationProperty<T> automationProperty)
        {
            T value;
            var success = automationProperty.TryGetValue(out value);
            return success ? (value == null ? String.Empty : value.ToString()) : "Not Supported";
        }
    }
}
