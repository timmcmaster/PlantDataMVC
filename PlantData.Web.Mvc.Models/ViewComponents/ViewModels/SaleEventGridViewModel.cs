using PlantData.Web.Mvc.Models.ViewModels.SaleEvent;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class SaleEventGridViewModel : BaseGridViewModel
    {
        public IEnumerable<SaleEventListViewModel> Items { get; set; } = new List<SaleEventListViewModel>();
    }
}
