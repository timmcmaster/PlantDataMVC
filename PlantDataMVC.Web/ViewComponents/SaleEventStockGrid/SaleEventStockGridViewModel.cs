using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;
using System.Collections.Generic;

namespace PlantDataMVC.Web.ViewComponents.SaleEventStockGrid
{
    public class SaleEventStockGridViewModel
    {
        public int? SaleEventId { get; set; }
        public IEnumerable<SaleEventStockListViewModel> SaleEventStocks { get; set; } = new List<SaleEventStockListViewModel>();
    }
}
