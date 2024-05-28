using PlantData.Web.Mvc.Models.ViewModels.SeedTray;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class SeedTrayGridViewModel : BaseGridViewModel
    {
        public IEnumerable<SeedTrayListViewModel> Items { get; set; } = new List<SeedTrayListViewModel>();
    }
}
