using PlantDataMVC.Web.Models.ViewModels.SeedTray;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class SeedTrayGridViewModel: BaseGridViewModel
    {
        public IEnumerable<SeedTrayListViewModel> Items { get; set; } = new List<SeedTrayListViewModel>();
    }
}
