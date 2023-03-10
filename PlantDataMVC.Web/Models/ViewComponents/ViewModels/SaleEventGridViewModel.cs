using PlantDataMVC.Web.Models.ViewModels.SaleEvent;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class SaleEventGridViewModel: BaseGridViewModel
    {
        public IEnumerable<SaleEventListViewModel> Items { get; set; } = new List<SaleEventListViewModel>();
    }
}
