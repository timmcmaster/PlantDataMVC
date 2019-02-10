using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UI.Controllers.Queries
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

    public class PlantStockDetailsQuery : IViewQuery<PlantStockDetailsViewModel>
    {

        public PlantStockDetailsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantStockDeleteQuery : IViewQuery<PlantStockDeleteViewModel>
    {

        public PlantStockDeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantStockEditQuery : IViewQuery<PlantStockEditViewModel>
    {

        public PlantStockEditQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class PlantStockShowQuery : IViewQuery<PlantStockShowViewModel>
    {

        public PlantStockShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}