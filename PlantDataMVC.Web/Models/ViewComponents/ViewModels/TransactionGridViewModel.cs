using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class TransactionGridViewModel : BaseGridViewModel
    {
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<TransactionListViewModel> Items { get; set; } = new List<TransactionListViewModel>();
    }
}
