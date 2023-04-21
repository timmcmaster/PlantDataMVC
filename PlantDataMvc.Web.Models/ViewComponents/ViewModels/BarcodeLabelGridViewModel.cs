using PlantDataMVC.Web.Models.ViewModels.Label;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class BarcodeLabelGridViewModel : BaseGridViewModel
    {
        public IEnumerable<BarcodeLabelListViewModel> Items { get; set; } = new List<BarcodeLabelListViewModel>();
    }
}
