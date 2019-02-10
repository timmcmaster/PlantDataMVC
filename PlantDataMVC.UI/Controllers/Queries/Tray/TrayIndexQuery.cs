using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Tray;

namespace PlantDataMVC.UI.Controllers.Queries.Tray
{
    public class TrayIndexQuery: IViewQuery<ListViewModelStatic<TrayListViewModel>>
    {

        public TrayIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}