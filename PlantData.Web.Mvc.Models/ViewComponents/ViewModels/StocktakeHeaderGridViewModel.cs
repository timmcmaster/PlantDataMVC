using PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class StocktakeHeaderGridViewModel : BaseGridViewModel
    {
        public IEnumerable<StocktakeHeaderListViewModel> Items { get; set; } = new List<StocktakeHeaderListViewModel>();
    }
}
