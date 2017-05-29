using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI.Models
{
    public class ListViewModel<T> : List<T>, IPageable, ISortable
    {
        public ListViewModel(IQueryable<T> source, int pageIndex, int pageSize, string sortBy, bool sortAscending)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = source.Count();
            this.TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.SortBy = sortBy;
            this.SortAscending = sortAscending;

            var sortedList = String.IsNullOrEmpty(this.SortBy) ? source : source.OrderBy(this.SortExpression);

            var pagedList = sortedList.Skip(PageIndex * PageSize).Take(PageSize);
            
            this.AddRange(pagedList);
        }

        // IPageable implementation
        public int PageIndex { get; private set; }
        public int PageSize   { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex+1 < TotalPages);
            }
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
