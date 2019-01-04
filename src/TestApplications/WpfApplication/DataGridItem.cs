using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class DataGridItem : ObservableObject
    {
        public string Name
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public int Number
        {
            get => GetProperty<int>();
            set => SetProperty(value);
        }

        public bool IsChecked
        {
            get => GetProperty<bool>();
            set => SetProperty(value);
        }
    }
}
