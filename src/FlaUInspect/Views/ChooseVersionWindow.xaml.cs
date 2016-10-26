using System.Windows;
using FlaUI.Core;

namespace FlaUInspect.Views
{
    /// <summary>
    /// Interaction logic for ChooseVersionWindow.xaml
    /// </summary>
    public partial class ChooseVersionWindow : Window
    {
        public ChooseVersionWindow()
        {
            InitializeComponent();
        }

        public AutomationType SelectedAutomationType { get; private set; }

        private void UIA2ButtonClick(object sender, RoutedEventArgs e)
        {
            SelectedAutomationType = AutomationType.UIA2;
            DialogResult = true;
        }

        private void UIA3ButtonClick(object sender, RoutedEventArgs e)
        {
            SelectedAutomationType = AutomationType.UIA3;
            DialogResult = true;
        }
    }
}
