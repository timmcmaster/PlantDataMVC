using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class SaleEventStockGridViewModel: BaseGridViewModel
    {
        public int? SaleEventId { get; set; }
        public IEnumerable<SaleEventStockListViewModel> Items { get; set; } = new List<SaleEventStockListViewModel>();
    }
}
