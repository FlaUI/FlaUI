using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FlaUI.Core.WindowsAPI;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Keyboard class to simulate key input.
    /// </summary>
    public static class Keyboard
    {
        /// <summary>
        /// Types the given text, one char after another.
        /// </summary>
        public static void Type(string text)
        {
            foreach (var c in text)
            {
                Type(c);
            }
        }

        /// <summary>
        /// Types the given character.
        /// </summary>
        public static void Type(char character)
        {
            var code = User32.VkKeyScan(character);
            // Check if the char is unicode or no virtual key could be found
            if (character > 0xFE || code == -1)
            {
                // It seems to be unicode
                SendInput(character, true, false, false, true);
                SendInput(character, false, false, false, true);
            }
            else
            {
                // Get the high-order and low-order byte from the code
                var high = (byte)(code >> 8);
                var low = (byte)(code & 0xff);

                // Check if there are any modifiers
                var modifiers = new List<VirtualKeyShort>();
                if (HasScanModifier(high, VkKeyScanModifiers.SHIFT))
                {
                    modifiers.Add(VirtualKeyShort.SHIFT);
                }
                if (HasScanModifier(high, VkKeyScanModifiers.CONTROL))
                {
                    modifiers.Add(VirtualKeyShort.CONTROL);
                }
                if (HasScanModifier(high, VkKeyScanModifiers.ALT))
                {
                    modifiers.Add(VirtualKeyShort.ALT);
                }
                // Press the modifiers
                foreach (var mod in modifiers)
                {
                    Press(mod);
                }
                // Type the effective key
                SendInput(low, true, false, false, false);
                SendInput(low, false, false, false, false);
                // Release the modifiers
                foreach (var mod in Enumerable.Reverse(modifiers))
                {
                    Release(mod);
                }
            }
        }

        /// <summary>
        /// Types the given keys, one by one.
        /// </summary>
        public static void Type(params VirtualKeyShort[] virtualKeys)
        {
            if (virtualKeys == null)
            {
                return;
            }
            foreach (var key in virtualKeys)
            {
                Press(key);
                Release(key);
            }
        }

        /// <summary>
        /// Types the given keys simultaneously (starting with the first).
        /// </summary>
        public static void TypeSimultaneously(params VirtualKeyShort[] virtualKeys)
        {
            if (virtualKeys == null)
            {
                return;
            }
            foreach (var key in virtualKeys)
            {
                Press(key);
            }
            foreach (var key in virtualKeys.Reverse())
            {
                Release(key);
            }
        }

        /// <summary>
        /// Types the given scan-code.
        /// </summary>
        public static void TypeScanCode(ushort scanCode, bool isExtendedKey)
        {
            PressScanCode(scanCode, isExtendedKey);
            ReleaseScanCode(scanCode, isExtendedKey);
        }

        /// <summary>
        /// Types the given virtual key-code.
        /// </summary>
        public static void TypeVirtualKeyCode(ushort virtualKeyCode)
        {
            PressVirtualKeyCode(virtualKeyCode);
            ReleaseVirtualKeyCode(virtualKeyCode);
        }

        /// <summary>
        /// Presses the given key.
        /// </summary>
        public static void Press(VirtualKeyShort virtualKey)
        {
            PressVirtualKeyCode((ushort)virtualKey);
        }

        /// <summary>
        /// Presses the given scan-code.
        /// </summary>
        public static void PressScanCode(ushort scanCode, bool isExtendedKey)
        {
            SendInput(scanCode, true, true, isExtendedKey, false);
        }

        /// <summary>
        /// Presses the given virtual key-code.
        /// </summary>
        public static void PressVirtualKeyCode(ushort virtualKeyCode)
        {
            SendInput(virtualKeyCode, true, false, false, false);
        }

        /// <summary>
        /// Releases the given key.
        /// </summary>
        public static void Release(VirtualKeyShort virtualKey)
        {
            ReleaseVirtualKeyCode((ushort)virtualKey);
        }

        /// <summary>
        /// Releases the given scan-code.
        /// </summary>
        public static void ReleaseScanCode(ushort scanCode, bool isExtendedKey)
        {
            SendInput(scanCode, false, true, isExtendedKey, false);
        }

        /// <summary>
        /// Releases the given virtual key-code.
        /// </summary>
        public static void ReleaseVirtualKeyCode(ushort virtualKeyCode)
        {
            SendInput(virtualKeyCode, false, false, false, false);
        }

        /// <summary>
        /// Presses the given key and releases it when the returned object is disposed.
        /// </summary>
        public static IDisposable Pressing(VirtualKeyShort virtualKey)
        {
            return new KeyPressingActivation(virtualKey);
        }

        /// <summary>
        /// Checks if a given byte has a specific VkKeyScan-modifier set.
        /// </summary>
        private static bool HasScanModifier(byte b, VkKeyScanModifiers modifierToTest)
        {
            return (VkKeyScanModifiers)(b & (byte)modifierToTest) == modifierToTest;
        }

        /// <summary>
        /// Effectively sends the keyboard input command.
        /// </summary>
        /// <param name="keyCode">The key code to send. Can be the scan code or the virtual key code.</param>
        /// <param name="isKeyDown">Flag if the key should be pressed or released.</param>
        /// <param name="isScanCode">Flag if the code is the scan code or the virtual key code.</param>
        /// <param name="isExtended">Flag if the key is an extended key.</param>
        /// <param name="isUnicode">Flag if the key is unicode.</param>
        private static void SendInput(ushort keyCode, bool isKeyDown, bool isScanCode, bool isExtended, bool isUnicode)
        {
            // Prepare the basic object
            var keyboardInput = new KEYBDINPUT
            {
                time = 0,
                dwExtraInfo = User32.GetMessageExtraInfo()
            };

            // Add the "key-up" flag if needed. By default it is "key-down"
            if (!isKeyDown)
            {
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_KEYUP;
            }

            if (isScanCode)
            {
                keyboardInput.wScan = keyCode;
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_SCANCODE;
                // Add the extended flag if the flag is set or the keycode is prefixed with the byte 0xE0
                // See https://msdn.microsoft.com/en-us/library/windows/desktop/ms646267(v=vs.85).aspx
                if (isExtended || (keyCode & 0xFF00) == 0xE0)
                {
                    keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_EXTENDEDKEY;
                }
            }
            else if (isUnicode)
            {
                keyboardInput.dwFlags |= KeyEventFlags.KEYEVENTF_UNICODE;
                keyboardInput.wScan = keyCode;
            }
            else
            {
                keyboardInput.wVk = keyCode;
            }

            // Build the input object
            var input = INPUT.KeyboardInput(keyboardInput);
            // Send the command
            if (User32.SendInput(1, new[] { input }, INPUT.Size) == 0)
            {
                // An error occured
                var errorCode = Marshal.GetLastWin32Error();
            }
        }

        /// <summary>
        /// Disposable class which presses the key on creation
        /// and disposes it on destruction.
        /// </summary>
        private class KeyPressingActivation : IDisposable
        {
            private readonly VirtualKeyShort _virtualKey;

            public KeyPressingActivation(VirtualKeyShort virtualKey)
            {
                _virtualKey = virtualKey;
                Press(_virtualKey);
            }

            public void Dispose()
            {
                Release(_virtualKey);
            }
        }
    }
}
