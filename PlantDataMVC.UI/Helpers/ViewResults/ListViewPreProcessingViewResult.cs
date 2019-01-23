using PlantDataMVC.UI.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Helpers.ViewResults
{
    /// <summary>
    /// A class for post-processing a View to display in a list view.
    /// </summary>
    public class ListViewPreProcessingViewResult<T> : PreProcessingViewResult
    {
        public int Page { get; }
        public int PageSize { get; }
        public string SortBy { get; }
        public bool Ascending { get; }

        public ListViewPreProcessingViewResult(PreProcessingViewResult child, int page, int pageSize, string sortBy, bool ascending)
            : base(child)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            Ascending = ascending;
        }

        protected override void PreProcessingTask()
        {
            ViewResult viewResult = GetRootViewResult();

            // Convert the enumerable model in the base view to a ListViewModel
            if (viewResult.ViewData.Model is IList<T> list)
            {
                viewResult.ViewData.Model = new  ListViewModel<T>(list.AsQueryable(), Page, PageSize, SortBy, Ascending);
            }
            else
            {
                //???
            }
        }
    }
}