using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers.Queries
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

    public class PlantDeleteQuery : IViewQuery<PlantDeleteViewModel>
    {

        public PlantDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantEditQuery : IViewQuery<PlantEditViewModel>
    {

        public PlantEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantShowQuery : IViewQuery<PlantShowViewModel>
    {

        public PlantShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}