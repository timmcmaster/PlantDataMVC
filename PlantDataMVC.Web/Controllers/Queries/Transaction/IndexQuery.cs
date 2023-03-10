using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Controllers.Queries.Transaction
{
    public class IndexQuery : IQuery<ListViewModelStatic<TransactionListViewModel>>
    {
        public IndexQuery(int? page, int? pageSize, string sortBy, bool sortAscending, int? speciesId = null, int? productTypeId = null)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            SortAscending = sortAscending;
            SpeciesId = speciesId;
            ProductTypeId = productTypeId;
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public int? SpeciesId { get; set; }
        public int? ProductTypeId { get; set; }

    }
}