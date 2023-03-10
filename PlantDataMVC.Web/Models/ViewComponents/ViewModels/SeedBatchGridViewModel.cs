using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class SeedBatchGridViewModel: BaseGridViewModel
    {
        public IEnumerable<SeedBatchListViewModel> Items { get; set; } = new List<SeedBatchListViewModel>();
    }
}
