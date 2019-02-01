namespace Framework.Web.Mvc.Sorting
{
    public interface ISortable
    {
        string SortBy { get; set; }
        bool SortAscending { get; set; }
        string SortExpression { get; }
    }
}