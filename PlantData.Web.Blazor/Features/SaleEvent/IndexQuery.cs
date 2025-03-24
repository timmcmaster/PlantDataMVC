using Framework.Web.Views;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.SaleEvent;

namespace PlantData.Web.Mvc.Controllers.Queries.SaleEvent
{
    public class IndexQuery : IQuery<GridDataModel<SaleEventGridModel>>
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