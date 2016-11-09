using System.Collections.Generic;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class DetailGroupViewModel : ObservableObject
    {
        public DetailGroupViewModel(string name, IEnumerable<DetailViewModel> details)
        {
            Name = name;
            Details = new ExtendedObservableCollection<DetailViewModel>(details);
        }

        public string Name { get { return GetProperty<string>(); } set { SetProperty(value); } }

        public ExtendedObservableCollection<DetailViewModel> Details { get; set; }
    }
}
