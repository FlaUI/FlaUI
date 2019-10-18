#if NETFRAMEWORK
using Accessibility;
using FlaUI.Core.Tools;

namespace FlaUI.UIA3.Patterns
{
    public partial class LegacyIAccessiblePattern
    {
        public override IAccessible GetIAccessible()
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return Com.Call(() => (IAccessible)NativePattern.GetIAccessible());
        }
    }
}
#endif
