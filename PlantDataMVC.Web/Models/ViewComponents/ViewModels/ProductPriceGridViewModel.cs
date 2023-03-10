using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class ProductPriceGridViewModel: BaseGridViewModel
    {
        public int? PriceListTypeId { get; set; }
        public IEnumerable<ProductPriceListViewModel> Items { get; set; } = new List<ProductPriceListViewModel>();
    }
}
