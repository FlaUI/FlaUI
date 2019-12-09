using System.Windows;
using System.Windows.Controls;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = vm;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                var textBlock = (TextBlock) item;
                if (textBlock.Text == "Item 4")
                {
                    MessageBox.Show("Do you really want to do it?");
                }
            }
        }
        
        private void OnShowLabel(object sender, RoutedEventArgs e)
        {
            MenuItem menuitem = sender as MenuItem;
            if (menuitem == null) { return; }
            
            if (menuitem.IsChecked == true)
            {
                lblMenuChk.Visibility = Visibility.Visible;
            }
            else
            {
                lblMenuChk.Visibility = Visibility.Hidden;
            }
        }
    }
}
