using FlaUI.UIA2;
using FlaUI.UIA3;
using FlaUInspect.Core;
using System.Collections.ObjectModel;

namespace FlaUInspect.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            var auto2 = new UIA2Automation();
            var desktop2 = auto2.GetDesktop();
            var desktopViewModel2 = new ElementViewModel(desktop2);
            desktopViewModel2.LoadChildren(false);
            ElementsV2 = new ObservableCollection<ElementViewModel>();
            ElementsV2.Add(desktopViewModel2);

            var auto3 = new UIA3Automation();
            var desktop3 = auto3.GetDesktop();
            var desktopViewModel3 = new ElementViewModel(desktop3);
            desktopViewModel3.LoadChildren(false);
            ElementsV3 = new ObservableCollection<ElementViewModel>();
            ElementsV3.Add(desktopViewModel3);
        }

        public ObservableCollection<ElementViewModel> ElementsV2 { get; set; }
        public ObservableCollection<ElementViewModel> ElementsV3 { get; set; }
    }
}
