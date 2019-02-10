using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Controllers.Queries.Plant
{
    public class PlantIndexQuery: IViewQuery<ListViewModelStatic<PlantListViewModel>>
    {

        public PlantIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}