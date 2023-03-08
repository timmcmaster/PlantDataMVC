using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Collections.Generic;

namespace PlantDataMVC.Web.ViewComponents.TransactionGrid
{
    public class TransactionGridViewModel
    {
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<TransactionListViewModel> Transactions { get; set; } = new List<TransactionListViewModel>();
    }
}
