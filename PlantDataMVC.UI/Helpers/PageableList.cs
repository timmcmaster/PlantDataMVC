using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PlantDataMVC.UI.Helpers
{
    public class PageableList<T> : List<T>, IPageable
    {
        public PageableList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var pagedList = source.Skip(PageIndex * PageSize).Take(PageSize);
            
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
