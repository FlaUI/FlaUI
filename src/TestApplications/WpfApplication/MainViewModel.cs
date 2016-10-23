using System.Collections.ObjectModel;

namespace WpfApplication
{
    public class MainViewModel
    {
        public ObservableCollection<DataGridItem> DataGridItems { get; }

        public MainViewModel()
        {
            DataGridItems = new ObservableCollection<DataGridItem>();
            DataGridItems.Add(new DataGridItem { Id = 1, Name = "Spongebob" });
            DataGridItems.Add(new DataGridItem { Id = 2, Name = "Patrick" });
            DataGridItems.Add(new DataGridItem { Id = 3, Name = "Tadeus" });
        }
    }
}
