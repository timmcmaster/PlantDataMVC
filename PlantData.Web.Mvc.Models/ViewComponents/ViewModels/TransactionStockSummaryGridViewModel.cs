using PlantData.Web.Mvc.Models.ViewModels.Transaction;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class TransactionStockSummaryGridViewModel : BaseGridViewModel
    {
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<TransactionStockSummaryListViewModel> Items { get; set; } = new List<TransactionStockSummaryListViewModel>();
    }
}
