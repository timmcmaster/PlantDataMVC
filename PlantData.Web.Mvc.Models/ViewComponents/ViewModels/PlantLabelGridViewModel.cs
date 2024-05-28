using PlantData.Web.Mvc.Models.ViewModels.Label;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class PlantLabelGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantLabelListViewModel> Items { get; set; } = new List<PlantLabelListViewModel>();
    }
}
