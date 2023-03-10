using PlantDataMVC.Web.Models.ViewModels.PlantStock;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class PlantStockGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantStockListViewModel> Items { get; set; } = new List<PlantStockListViewModel>();
    }
}
