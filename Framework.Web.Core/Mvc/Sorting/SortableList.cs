using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Framework.Web.Core.Mvc.Sorting
{
    public class SortableList<T> : List<T>, ISortable
    {
        public SortableList(IQueryable<T> source, string sortBy, bool sortAscending)
        {
            SortBy = sortBy;
            SortAscending = sortAscending;

            var sortedList = string.IsNullOrEmpty(SortBy) ? source : source.OrderBy(SortExpression);

            AddRange(sortedList);
        }

        #region ISortable Members
        // ISortable implementation
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }

        public string SortExpression
        {
            get => SortAscending ? SortBy + " asc" : SortBy + " desc";
        }
        #endregion
    }
}