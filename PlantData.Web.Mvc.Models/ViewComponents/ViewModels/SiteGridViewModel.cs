using PlantData.Web.Mvc.Models.ViewModels.Site;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class SiteGridViewModel : BaseGridViewModel
    {
        public IEnumerable<SiteListViewModel> Items { get; set; } = new List<SiteListViewModel>();
    }
}
