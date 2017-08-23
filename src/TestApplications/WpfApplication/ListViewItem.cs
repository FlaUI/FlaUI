using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class ListViewItem : ObservableObject
    {
        public string Key
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public string Value
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }
    }
}
