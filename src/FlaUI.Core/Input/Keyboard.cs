using FlaUI.Core.WindowsAPI;
using System.Runtime.InteropServices;
using System.Threading;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Implementation for the keyboard
    /// </summary>
    public class Keyboard : IKeyboard
    {
        public void Press(ushort keyCode)
        {
            KeyDown(keyCode);
            KeyUp(keyCode);
        }

        public void Write(string textToWrite)
        {
            foreach (var c in textToWrite)
            {
                var keyCode = (ushort)User32.VkKeyScan(c);
                Press(keyCode);
            }
        }

        public void KeyDown(char character)
        {
            KeyDown((ushort)User32.VkKeyScan(character));
        }

        public void KeyDown(SpecialKeys specialKey)
        {
            KeyDown((ushort)specialKey);
        }

        public void KeyDown(ushort keyCode)
        {
            var keyboardInput = GetInputForCharacter(keyCode, true);
            SendInput(keyboardInput);
        }

        public void KeyUp(char character)
        {
            KeyUp((ushort)User32.VkKeyScan(character));
        }

        public void KeyUp(SpecialKeys specialKey)
        {
            KeyUp((ushort)specialKey);
        }

        public void KeyUp(ushort keyCode)
        {
            var keyboardInput = GetInputForCharacter(keyCode, false);
            SendInput(keyboardInput);
        }

        /// <summary>
        /// Converts the character to the correct <see cref="KEYBDINPUT"/> object
        /// </summary>
        private KEYBDINPUT GetInputForCharacter(ushort keyCode, bool isDown)
        {
            var keyEvent = isDown ? KeyEventFlags.KEYEVENTF_KEYDOWN : KeyEventFlags.KEYEVENTF_KEYUP;
            return new KEYBDINPUT(keyCode, keyEvent, User32.GetMessageExtraInfo());
        }

        /// <summary>
        /// Effectively sends the keyboard input command
        /// </summary>
        private void SendInput(KEYBDINPUT keyboardInput)
        {
            var input = INPUT.KeyboardInput(keyboardInput);
            User32.SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
