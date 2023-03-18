using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{
    public class TransactionStocktakeGridViewModel : BaseGridViewModel
    {
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }
        public IEnumerable<TransactionStocktakeListViewModel> Items { get; set; } = new List<TransactionStocktakeListViewModel>();
    }
}
