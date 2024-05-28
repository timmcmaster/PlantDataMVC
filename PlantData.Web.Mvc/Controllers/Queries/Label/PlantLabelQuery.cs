using Framework.Web.Views;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Label;

namespace PlantData.Web.Mvc.Controllers.Queries.Label

{
    public class PlantLabelQuery : IQuery<ListViewModelStatic<PlantLabelListViewModel>>
    {
        public PlantLabelQuery(int? page, int? pageSize, string sortBy, bool sortAscending)
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