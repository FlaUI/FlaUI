using interop.ShObjIdl;
using System;
using System.Diagnostics;

namespace FlaUI.Core.Tools
{
    public static class WindowsStoreAppLauncher
    {
        public static Process Launch(string appUserModelId, string arguments)
        {
            var launcher = new ApplicationActivationManager();
            uint processId;
            launcher.ActivateApplication(appUserModelId, arguments, ACTIVATEOPTIONS.AO_NONE, out processId);
            if (processId > 0)
            {
                return Process.GetProcessById((int)processId);
            }
            throw new Exception(String.Format("Could not launch Store App '{0}'", appUserModelId));
        }
    }
}
