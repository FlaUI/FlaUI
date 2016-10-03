using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.UIA3
{
    public class UIA3PropertyLibrary : IPropertyLibray
    {
        public UIA3PropertyLibrary()
        {
            Generic = new UIA3ElementProperties();
        }

        public IElementProperties Generic { get; }
    }
}
