using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<DataGridItem> DataGridItems { get; }

        public ICommand InvokeButtonCommand { get; }

        public string InvokeButtonText
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public MainViewModel()
        {
            DataGridItems = new ObservableCollection<DataGridItem>
            {
                new DataGridItem { Name = "John", Number = 12, IsChecked = false },
                new DataGridItem { Name = "Doe", Number = 24, IsChecked = true },
            };

            InvokeButtonText = "Invoke me!";
            InvokeButtonCommand = new RelayCommand(o => InvokeButtonText = "Invoked!");
        }
    }
}
