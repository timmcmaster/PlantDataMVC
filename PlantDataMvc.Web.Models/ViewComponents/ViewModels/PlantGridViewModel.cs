using PlantDataMVC.Web.Models.ViewModels.Plant;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class PlantGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantListViewModel> Items { get; set; } = new List<PlantListViewModel>();
    }
}
