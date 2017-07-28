namespace Framework.Web.Mvc.Paging
{
    public interface IPageable
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
