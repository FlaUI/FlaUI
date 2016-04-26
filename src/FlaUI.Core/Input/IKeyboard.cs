using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Core.Input
{
    /// <summary>
    /// Interface for the keyboard
    /// </summary>
    public interface IKeyboard
    {
        void Press(ushort keyCode);

        void Write(string textToWrite);
    }
}
