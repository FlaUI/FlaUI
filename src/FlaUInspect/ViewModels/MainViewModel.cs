using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using FlaUI.Core;
using FlaUI.UIA2;
using FlaUI.UIA3;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementViewModel>();
            StartNewInstanceCommand = new RelayCommand(o => {
                var info = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location);
                Process.Start(info);
            });
        }

        public bool IsInitialized { get { return GetProperty<bool>(); } private set { SetProperty(value); } }

        public AutomationType SelectedAutomationType { get { return GetProperty<AutomationType>(); } private set { SetProperty(value); } }

        public ObservableCollection<ElementViewModel> Elements { get; private set; }

        public ICommand StartNewInstanceCommand { get; private set; }

        public ObservableCollection<DetailViewModel> SelectedItemDetails { get; set; }

        public void Initialize(AutomationType selectedAutomationType)
        {
            SelectedAutomationType = selectedAutomationType;
            IsInitialized = true;

            AutomationBase automation;
            if (selectedAutomationType == AutomationType.UIA2)
            {
                automation = new UIA2Automation();
            }
            else
            {
                automation = new UIA3Automation();
            }
            var desktop = automation.GetDesktop();
            var desktopViewModel = new ElementViewModel(desktop);
            desktopViewModel.SelectionChanged += DesktopViewModel_SelectionChanged;
            desktopViewModel.LoadChildren(false);
            Elements.Add(desktopViewModel);
        }

        private void DesktopViewModel_SelectionChanged(ElementViewModel obj)
        {
            SelectedItemDetails = obj.ItemDetails;
            OnPropertyChanged(() => SelectedItemDetails);
        }
    }
}
