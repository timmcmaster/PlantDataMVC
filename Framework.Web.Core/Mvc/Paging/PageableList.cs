using System;
using System.Linq;

namespace Framework.Web.Core.Mvc.Paging
{
    public class PageableList<T> : BasePageableList<T>
    {
        public PageableList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = TotalCount > 0 ? (int) Math.Ceiling(TotalCount / (double) PageSize) : 0;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;

            var pagedList = source.Skip((PageNumber - 1) * PageSize).Take(PageSize);

            AddRange(pagedList);
        }
    }
}