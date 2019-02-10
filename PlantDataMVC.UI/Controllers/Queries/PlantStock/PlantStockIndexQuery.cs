using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UI.Controllers.Queries.PlantStock
{
    public class PlantStockIndexQuery: IViewQuery<ListViewModelStatic<PlantStockListViewModel>>
    {

        public PlantStockIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}