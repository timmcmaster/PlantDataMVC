using PlantDataMVC.Web.Models.ViewModels.Genus;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class GenusGridViewModel : BaseGridViewModel
    {
        public IEnumerable<GenusListViewModel> Items { get; set; } = new List<GenusListViewModel>();
    }
}
