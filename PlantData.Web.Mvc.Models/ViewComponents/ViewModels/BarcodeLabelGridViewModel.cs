using PlantData.Web.Mvc.Models.ViewModels.Label;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class BarcodeLabelGridViewModel : BaseGridViewModel
    {
        public IEnumerable<BarcodeLabelListViewModel> Items { get; set; } = new List<BarcodeLabelListViewModel>();
    }
}
