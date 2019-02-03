using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers.Queries
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
    public class PlantSeedDeleteQuery : IViewQuery<PlantSeedDeleteViewModel>
    {

        public PlantSeedDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantSeedEditQuery : IViewQuery<PlantSeedEditViewModel>
    {

        public PlantSeedEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantSeedShowQuery : IViewQuery<PlantSeedShowViewModel>
    {

        public PlantSeedShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}