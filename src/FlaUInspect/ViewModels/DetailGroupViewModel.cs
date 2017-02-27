using System.Collections.Generic;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class DetailGroupViewModel : ObservableObject
    {
        public DetailGroupViewModel(string name, IEnumerable<IDetailViewModel> details)
        {
            Name = name;
            Details = new ExtendedObservableCollection<IDetailViewModel>(details);
        }

        public string Name { get { return GetProperty<string>(); } set { SetProperty(value); } }

        public ExtendedObservableCollection<IDetailViewModel> Details { get; set; }
    }
}
