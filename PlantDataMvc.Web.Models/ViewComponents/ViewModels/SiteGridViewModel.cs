using PlantDataMVC.Web.Models.ViewModels.Site;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class SiteGridViewModel: BaseGridViewModel
    {
        public IEnumerable<SiteListViewModel> Items { get; set; } = new List<SiteListViewModel>();
    }
}
