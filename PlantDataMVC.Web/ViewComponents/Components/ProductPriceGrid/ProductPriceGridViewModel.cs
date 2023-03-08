using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Views.Shared.Components.ProductPriceGrid
{
    public class ProductPriceGridViewModel
    {
        public int? PriceListTypeId { get; set; }
        public IEnumerable<ProductPriceListViewModel> ProductPrices { get; set; } = new List<ProductPriceListViewModel>();
    }
}
