using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Framework.Web.Mvc.Paging
{
    public class PageableList<T> : List<T>, IPageable
    {
        public PageableList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var pagedList = source.Skip(PageIndex * PageSize).Take(PageSize);

            AddRange(pagedList);
        }

        // IPageable implementation
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get => PageIndex > 0;
        }

        public bool HasNextPage
        {
            get => PageIndex + 1 < TotalPages;
        }


        // ISortable implementation
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public string SortExpression
        {
            get => SortAscending ? SortBy + " asc" : SortBy + " desc";
        }
    }
}
