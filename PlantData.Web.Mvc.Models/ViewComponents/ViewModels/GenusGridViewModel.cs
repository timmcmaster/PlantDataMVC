using PlantData.Web.Mvc.Models.ViewModels.Genus;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class GenusGridViewModel : BaseGridViewModel
    {
        public IEnumerable<GenusListViewModel> Items { get; set; } = new List<GenusListViewModel>();
    }
}
