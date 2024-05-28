using PlantData.Web.Mvc.Models.ViewModels.PlantStock;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class PlantStockGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantStockListViewModel> Items { get; set; } = new List<PlantStockListViewModel>();
    }
}
