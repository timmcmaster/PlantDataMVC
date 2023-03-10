using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class TransactionStockSummaryGridViewModel : BaseGridViewModel
    {
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<TransactionStockSummaryListViewModel> Items { get; set; } = new List<TransactionStockSummaryListViewModel>();
    }
}
