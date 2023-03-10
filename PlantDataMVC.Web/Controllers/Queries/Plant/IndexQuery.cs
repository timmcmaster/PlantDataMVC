using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Plant;

namespace PlantDataMVC.Web.Controllers.Queries.Plant
{
    public class IndexQuery : IQuery<ListViewModelStatic<PlantListViewModel>>
    {
        public IndexQuery(int? page, int? pageSize, string sortBy, bool sortAscending)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
    }
}