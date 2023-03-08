using PlantDataMVC.Web.Models.ViewModels.Plant;
using System.Collections.Generic;

namespace PlantDataMVC.Web.ViewComponents.PlantGrid
{
    public class PlantGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantListViewModel> Items;
    }
}
