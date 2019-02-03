using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers.Queries
{
    public class PlantStockTransactionIndexQuery : IViewQuery<ListViewModelStatic<PlantStockTransactionListViewModel>>
    {

        public PlantStockTransactionIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class PlantStockTransactionDeleteQuery : IViewQuery<PlantStockTransactionDeleteViewModel>
    {

        public PlantStockTransactionDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantStockTransactionEditQuery : IViewQuery<PlantStockTransactionEditViewModel>
    {

        public PlantStockTransactionEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}