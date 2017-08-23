using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class DataGridItem : ObservableObject
    {
        public int Id
        {
            get => GetProperty<int>();
            set => SetProperty(value);
        }

        public string Name
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }
    }
}
