using PlantDataMVC.UI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Helpers.ViewResults
{
    /// <summary>
    /// A class for post-processing a View to display in a list view.
    /// </summary>
    public class ApiListViewPreProcessingViewResult<T> : PreProcessingViewResult
    {
        public ApiPagingInfo PagingInfo { get; }
        public string SortBy { get; }
        public bool Ascending { get; }

        public ApiListViewPreProcessingViewResult(PreProcessingViewResult child, ApiPagingInfo pagingInfo, string sortBy, bool ascending)
            : base(child)
        {
            PagingInfo = pagingInfo;
            SortBy = sortBy;
            Ascending = ascending;
        }

        protected override void PreProcessingTask()
        {
            ViewResult viewResult = GetRootViewResult();

            // Convert the enumerable model in the base view to a ListViewModel
            if (viewResult.ViewData.Model is IList<T> list)
            {
                viewResult.ViewData.Model = new  ListViewModelStatic<T>(list, PagingInfo.page, PagingInfo.pageSize, PagingInfo.totalCount);
            }
            else
            {
                //???
            }
        }
    }
}