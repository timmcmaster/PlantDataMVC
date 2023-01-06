using Framework.Web.Mvc.Paging;
using Framework.Web.Mvc.Sorting;
using System.Collections.Generic;

namespace PlantDataMVC.UICore.Models.ViewModels
{
    public class ListViewModelStatic<T> : StaticPageableList<T>, ISortable
    {
        public ListViewModelStatic(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount, string sortBy, bool sortAscending)
            : this(subset, pageNumber, pageSize, totalCount)
        {
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public ListViewModelStatic(IEnumerable<T> subset, int pageNumber, int pageSize, int totalCount) : base(subset, pageNumber, pageSize, totalCount)
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
