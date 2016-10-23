using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<DataGridItem> DataGridItems { get; }

        public ICommand InvokeButtonCommand { get; }

        public string InvokeButtonText { get { return GetProperty<string>(); } set { SetProperty(value); } }

        public MainViewModel()
        {
            DataGridItems = new ObservableCollection<DataGridItem>();
            DataGridItems.Add(new DataGridItem { Id = 1, Name = "Spongebob" });
            DataGridItems.Add(new DataGridItem { Id = 2, Name = "Patrick" });
            DataGridItems.Add(new DataGridItem { Id = 3, Name = "Tadeus" });

            InvokeButtonText = "Invoke me!";
            InvokeButtonCommand = new RelayCommand(o => InvokeButtonText = "Invoked!");
        }
    }
}
