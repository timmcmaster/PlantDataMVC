using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Framework.Web.Mvc.Sorting

{
    public class SortableList<T> : List<T>, ISortable
    {
        public SortableList(IQueryable<T> source, string sortBy, bool sortAscending)
        {
            this.SortBy = sortBy;
            this.SortAscending = sortAscending;

            var sortedList = String.IsNullOrEmpty(this.SortBy) ? source : source.OrderBy(this.SortExpression);

            this.AddRange(sortedList);
        }

        // ISortable implementation
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public string SortExpression
        {
            get
            {
                return this.SortAscending ? this.SortBy + " asc" : this.SortBy + " desc";
            }
        }
    }
}
