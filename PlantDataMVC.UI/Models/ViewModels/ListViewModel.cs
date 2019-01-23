using Framework.Web.Mvc.Paging;
using Framework.Web.Mvc.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class ListViewModel<T> : List<T>, IPageable, ISortable
    {
        public ListViewModel(IQueryable<T> source, int pageIndex, int pageSize, string sortBy, bool sortAscending)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int) Math.Ceiling(TotalCount / (double) PageSize);

            SortBy = sortBy;
            SortAscending = sortAscending;

            IQueryable<T> sortedList = string.IsNullOrEmpty(SortBy) ? source : source.OrderBy(SortExpression);

            IQueryable<T> pagedList = sortedList.Skip(PageIndex * PageSize).Take(PageSize);

            AddRange(pagedList);
        }

        // IPageable implementation
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }

        public bool HasPreviousPage
        {
            get => (PageIndex > 0);
        }

        public bool HasNextPage
        {
            get => (PageIndex + 1 < TotalPages);
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
