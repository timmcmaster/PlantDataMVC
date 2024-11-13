using System;

namespace PlantData.Web.Blazor.SharedComponents.Paging
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public PagingModel(int pageSize, int pageNumber, int totalCount)
        {
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var hasPrevious = pageNumber > 1;
            var hasNext = pageNumber < totalPages;

            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalCount = totalCount;
            TotalPages = totalPages;
            HasPreviousPage = hasPrevious;
            HasNextPage = hasNext;
        }
    }
}
