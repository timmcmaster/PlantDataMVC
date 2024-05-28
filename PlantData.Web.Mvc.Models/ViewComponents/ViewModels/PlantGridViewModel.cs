using PlantData.Web.Mvc.Models.ViewModels.Plant;
using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class PlantGridViewModel : BaseGridViewModel
    {
        public IEnumerable<PlantListViewModel> Items { get; set; } = new List<PlantListViewModel>();
    }
}
