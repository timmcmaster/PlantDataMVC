using PlantDataMVC.Web.Models.ViewModels.StocktakeHeader;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class StocktakeHeaderGridViewModel: BaseGridViewModel
    {
        public IEnumerable<StocktakeHeaderListViewModel> Items { get; set; } = new List<StocktakeHeaderListViewModel>();
    }
}
