using PlantData.Web.Mvc.Models.ViewModels.PriceListType;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class PriceListTypeGridViewModel : BaseGridViewModel
    {
        public int? PriceListTypeId { get; set; }
        public IEnumerable<PriceListTypeListViewModel> Items { get; set; } = new List<PriceListTypeListViewModel>();
    }
}
