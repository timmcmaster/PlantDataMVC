using System.Linq;
using System.Linq.Dynamic;

namespace Framework.Web.Mvc.Sorting
{
    public static class SortableExtensions
    {
        public static IQueryable<T> SortQueryable<T>(this IQueryable<T> source, string sortBy, bool sortAscending)
        {
            return string.IsNullOrEmpty(sortBy)
                ? source
                : source.OrderBy(sortAscending ? sortBy + " asc" : sortBy + " desc");

        }
    }
}