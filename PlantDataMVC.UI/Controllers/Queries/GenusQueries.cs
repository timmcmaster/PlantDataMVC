using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers.Queries
{
    public class GenusIndexQuery: IViewQuery<ListViewModelStatic<GenusListViewModel>>
    {

        public GenusIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class GenusDeleteQuery : IViewQuery<GenusDeleteViewModel>
    {

        public GenusDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GenusEditQuery : IViewQuery<GenusEditViewModel>
    {

        public GenusEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GenusShowQuery : IViewQuery<GenusShowViewModel>
    {

        public GenusShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}