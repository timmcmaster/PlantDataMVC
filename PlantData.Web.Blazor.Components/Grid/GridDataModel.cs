using Framework.Web.Mvc.Paging;
using Framework.Web.Mvc.Sorting;
using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class GridDataModel<T> : StaticPageableList<T>, ISortable
    {
        public GridDataModel(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount, string sortBy, bool sortAscending) : this(subset, pageNumber, pageSize, totalCount)
        {
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public GridDataModel(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount) : base(subset, pageNumber, pageSize, totalCount)
        {
        }


        #region ISortable implementation

        public string SortBy { get; set; }
        public bool SortAscending { get; set; }

        public string SortExpression
        {
            get => SortAscending ? SortBy + " asc" : SortBy + " desc";
        }

        #endregion
    }
}
