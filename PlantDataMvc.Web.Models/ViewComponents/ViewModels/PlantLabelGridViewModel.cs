using PlantDataMVC.Web.Models.ViewModels.Label;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class PlantLabelGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantLabelListViewModel> Items { get; set; } = new List<PlantLabelListViewModel>();
    }
}
