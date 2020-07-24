using System;
using FlaUI.Custom;

namespace WpfApplication.Controls
{
    public static class CustomProperties
    {
        public static CustomProperty ForegroundProperty = new CustomProperty(new Guid("e679d5ff-ec48-47d0-b2b6-a76f7a1ac9cc"), "Foreground", PropertyType.String);
        public static CustomProperty BackgroundProperty = new CustomProperty(new Guid("f267b0eb-f4ea-4724-b7e0-347bded70c40"), "Background", PropertyType.String);
    }
}
