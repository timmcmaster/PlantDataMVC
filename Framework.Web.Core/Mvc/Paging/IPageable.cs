namespace Framework.Web.Core.Mvc.Paging
{
    public interface IPageable
    {
        /// <summary>
        ///     One-based index for page number.
        /// </summary>
        /// <value>
        ///     The page number.
        /// </value>
        int PageNumber { get; }

        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}