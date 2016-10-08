using FlaUI.Core.Patterns.Infrastructure;

namespace FlaUI.Core.Patterns
{
    public interface IObjectModelPattern : IPattern
    {
        object GetUnderlyingObjectModel();
    }
}
