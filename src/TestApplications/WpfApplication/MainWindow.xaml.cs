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
                var textBlock = (TextBlock)item;
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

        private void OnDisableForm(object sender, RoutedEventArgs e)
        {
            textBox.IsEnabled = false;
            passwordBox.IsEnabled = false;
            editableCombo.IsEnabled = false;
            nonEditableCombo.IsEnabled = false;
            listBox.IsEnabled = false;
            checkBox.IsEnabled = false;
            threeStateCheckbox.IsEnabled = false;
            radioButton1.IsEnabled = false;
            radioButton2.IsEnabled = false;
            slider.IsEnabled = false;
            invokableButton.IsEnabled = false;
            PopupToggleButton1.IsEnabled = false;
            lblMenuChk.IsEnabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window1();
            window.Show();
        }
    }
}
