using PlantDataMVC.Web.Models.ViewModels.Plant;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Views.Shared.Components.PlantGrid
{
    public class PlantGridViewModel: BaseGridViewModel
    {
        public IEnumerable<PlantListViewModel> Items;
    }
}
