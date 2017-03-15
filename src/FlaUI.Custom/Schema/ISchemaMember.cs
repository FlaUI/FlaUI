namespace ManagedUiaCustomizationCore
{
    public interface ISchemaMember
    {
        void DispatchCallToProvider(object provider, UiaParameterListHelper paramList);
        bool SupportsDispatch { get; }
    }
}