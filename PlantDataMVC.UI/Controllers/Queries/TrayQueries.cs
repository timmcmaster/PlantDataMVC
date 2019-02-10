using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Tray;

namespace PlantDataMVC.UI.Controllers.Queries
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

    public class TrayDeleteQuery : IViewQuery<TrayDeleteViewModel>
    {

        public TrayDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class TrayEditQuery : IViewQuery<TrayEditViewModel>
    {

        public TrayEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class TrayShowQuery : IViewQuery<TrayShowViewModel>
    {

        public TrayShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}