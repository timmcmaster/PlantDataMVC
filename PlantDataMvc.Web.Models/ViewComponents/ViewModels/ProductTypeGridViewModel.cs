using PlantDataMVC.Web.Models.ViewModels.ProductType;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class ProductTypeGridViewModel: BaseGridViewModel
    {
        public int? PriceListTypeId { get; set; }
        public IEnumerable<ProductTypeListViewModel> Items { get; set; } = new List<ProductTypeListViewModel>();
    }
}
