using Framework.Web.Mvc.Paging;
using Framework.Web.Mvc.Sorting;

namespace PlantDataMVC.Web.Models.ViewComponents.ViewModels
{

    public class BaseGridViewModel : IPageable, ISortable
    {
        public GridOptionsModel Options { get; set; } = new();

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public string SortBy { get; set; } = string.Empty;
        public bool SortAscending { get; set; }
        public string SortExpression { get; set; } = string.Empty;
    }
}
