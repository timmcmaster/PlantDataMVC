using Framework.Web.Mvc.Paging;
using Framework.Web.Mvc.Sorting;
using System.Collections.Generic;

namespace PlantDataMVC.Web.ViewComponents.PlantGrid
{
    public class BaseGridViewModel : IPageable, ISortable
    {
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }

        public bool AllowPaging { get; set; }
        public bool AllowSorting { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public string SortExpression { get; set; }
    }
}
