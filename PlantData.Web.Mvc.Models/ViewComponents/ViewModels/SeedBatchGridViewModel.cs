using PlantData.Web.Mvc.Models.ViewModels.SeedBatch;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class SeedBatchGridViewModel : BaseGridViewModel
    {
        public IEnumerable<SeedBatchListViewModel> Items { get; set; } = new List<SeedBatchListViewModel>();
    }
}
