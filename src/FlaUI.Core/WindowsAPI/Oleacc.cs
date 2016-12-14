using System.Runtime.InteropServices;
using System.Text;

namespace FlaUI.Core.WindowsAPI
{
    public static class Oleacc
    {
        [DllImport("oleacc.dll")]
        public static extern uint GetRoleText(AccessibilityRole dwRole, [Out] StringBuilder lpszRole, uint cchRoleMax);

        [DllImport("oleacc.dll")]
        public static extern uint GetStateText(AccessibilityState dwStateBit, [Out] StringBuilder lpszStateBit, uint cchStateBitMax);
    }
}
