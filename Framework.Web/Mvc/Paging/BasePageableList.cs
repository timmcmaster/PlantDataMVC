using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Web.Mvc.Paging
{
    public abstract class BasePageableList<T> : List<T>, IPageable
    {
        protected BasePageableList()
        {
        }

        protected BasePageableList(int pageNumber, int pageSize, int totalCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = TotalCount > 0 ? (int)Math.Ceiling(TotalCount / (double)PageSize) : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;
        }

        #region IPageable implementation

        public int PageNumber { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalCount { get; protected set; }
        public int TotalPages { get; protected set; }
        public bool HasPreviousPage { get; protected set; }
        public bool HasNextPage { get; protected set; }

        #endregion
    }
}