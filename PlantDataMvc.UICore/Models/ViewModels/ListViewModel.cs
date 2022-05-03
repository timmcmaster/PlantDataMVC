using Framework.Web.Core.Mvc.Paging;
using Framework.Web.Core.Mvc.Sorting;
using System.Linq;

namespace PlantDataMVC.UICore.Models.ViewModels
{
    public class ListViewModel<T> : PageableList<T>, ISortable
    {
        public ListViewModel(IQueryable<T> superset, int pageNumber, int pageSize, string sortBy, bool sortAscending)
            : this(superset.SortQueryable(sortBy, sortAscending), pageNumber, pageSize)
        {
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public ListViewModel(IQueryable<T> superset, int pageNumber, int pageSize) : base(superset, pageNumber,
            pageSize)
        {
        }

        public string SortBy { get; set; }
        public bool SortAscending { get; set; }

        public string SortExpression
        {
            get => SortAscending ? SortBy + " asc" : SortBy + " desc";
        }
    }
}
