using PlantData.Web.Mvc.Models.ViewModels.SaleEventStock;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class SaleEventStockGridViewModel : BaseGridViewModel
    {
        public int? SaleEventId { get; set; }
        public IEnumerable<SaleEventStockListViewModel> Items { get; set; } = new List<SaleEventStockListViewModel>();
    }
}
