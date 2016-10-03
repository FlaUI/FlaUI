using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.UIA2
{
    public class UIA2PropertyLibrary : IPropertyLibray
    {
        public UIA2PropertyLibrary()
        {
            Generic = new UIA2ElementProperties();
        }

        public IElementProperties Generic { get; }
    }
}
