using System.Windows;
using FlaUI.Custom;
using WpfApplication.Controls;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Registrar.RegisterStandaloneProperty(CustomProperties.BackgroundProperty);
            Registrar.RegisterStandaloneProperty(CustomProperties.ForegroundProperty);
            base.OnStartup(e);
        }
    }
}
