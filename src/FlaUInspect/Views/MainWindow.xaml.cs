using System.Windows;
using FlaUInspect.ViewModels;

namespace FlaUInspect.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainViewModel();
            DataContext = vm;
        }
    }
}
