using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Interface for the keyboard
    /// </summary>
    public interface IKeyboard
    {
        void Type(char character);
        void TypeScanCode(ushort scanCode, bool isExtendedKey);
        void TypeVirtualKeyCode(ushort virtualKeyCode);
        void TypeVirtualKeyCode(VirtualKeyShort virtualKey);
        void PressScanCode(ushort scanCode, bool isExtendedKey);
        void PressVirtualKeyCode(ushort virtualKeyCode);
        void PressVirtualKeyCode(VirtualKeyShort virtualKey);
        void ReleaseScanCode(ushort scanCode, bool isExtendedKey);
        void ReleaseVirtualKeyCode(ushort virtualKeyCode);
        void ReleaseVirtualKeyCode(VirtualKeyShort virtualKey);
        void Write(string textToWrite);
    }
}
