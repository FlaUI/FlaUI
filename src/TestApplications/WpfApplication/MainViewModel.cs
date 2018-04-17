using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication.Infrastructure;

namespace WpfApplication
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<DataGridItem> DataGridItems { get; }

        public ICommand InvokeButtonCommand { get; }

        public ICommand HiddenButtonCommand { get; }

        public string InvokeButtonText
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public string HiddenButtonText
        {
            get => GetProperty<string>();
            set => SetProperty(value);
        }

        public MainViewModel()
        {
            DataGridItems = new ObservableCollection<DataGridItem>
            {
                new DataGridItem { Id = 1, Name = "Spongebob" },
                new DataGridItem { Id = 2, Name = "Patrick" },
                new DataGridItem { Id = 3, Name = "Tadeus" }
            };

            InvokeButtonText = "Invoke me!";
            InvokeButtonCommand = new RelayCommand(o => InvokeButtonText = "Invoked!");

            HiddenButtonText = "Find and click on me";
            HiddenButtonCommand = new RelayCommand(o => HiddenButtonText = "Invoked!");
        }
    }
}
