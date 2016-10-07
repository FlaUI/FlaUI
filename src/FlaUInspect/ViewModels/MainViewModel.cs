using System;
using System.Collections.ObjectModel;
using FlaUI.UIA2;
using FlaUI.UIA3;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            var auto2 = new UIA2Automation();
            var auto3 = new UIA3Automation();

            //var desk2 = auto2.GetDesktop();
            var desk3 = auto3.GetDesktop();

            //Console.WriteLine(desk2.Current.BoundingRectangle.ToString());
            Console.WriteLine(desk3.Current.BoundingRectangle.ToString());

            Elements = new ObservableCollection<ElementViewModel>();

            var desktop = auto3.GetDesktop();
            var treeWalker = new TreeWalker(auto3);

            Elements.Add(new ElementViewModel(desktop));
        }

        public ObservableCollection<ElementViewModel> Elements { get; set; }
    }
}
