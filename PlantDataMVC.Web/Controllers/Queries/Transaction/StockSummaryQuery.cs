using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Controllers.Queries.Transaction
{
    public class StockSummaryQuery : IQuery<ListViewModelStatic<TransactionStockSummaryListViewModel>>
    {
        public StockSummaryQuery(int? page, int? pageSize, string sortBy, bool sortAscending)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
    }
}