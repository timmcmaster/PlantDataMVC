using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers.Queries
{
    public class SiteIndexQuery: IViewQuery<ListViewModelStatic<SiteListViewModel>>
    {

        public SiteIndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class SiteDeleteQuery : IViewQuery<SiteDeleteViewModel>
    {

        public SiteDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class SiteEditQuery : IViewQuery<SiteEditViewModel>
    {

        public SiteEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class SiteShowQuery : IViewQuery<SiteShowViewModel>
    {

        public SiteShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}