using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Seed;

namespace PlantDataMVC.UI.Controllers.Queries.Seed
{
    public class PlantSeedIndexQuery: IViewQuery<ListViewModelStatic<PlantSeedListViewModel>>
    {

        public PlantSeedIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}