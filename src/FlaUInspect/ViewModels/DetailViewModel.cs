using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class DetailViewModel : ObservableObject
    {
        public DetailViewModel(string key, object value)
        {
            Key = key;
            Value = value.ToString();
        }

        public string Key { get { return GetProperty<string>(); } set { SetProperty(value); } }
        public string Value { get { return GetProperty<string>(); } set { SetProperty(value); } }
    }
}
