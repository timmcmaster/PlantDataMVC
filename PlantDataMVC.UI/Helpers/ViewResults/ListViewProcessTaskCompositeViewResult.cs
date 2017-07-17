using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PlantDataUI.Models;

namespace PlantDataUI.Helpers
{
    /// <summary>
    /// A class for post-processing a View to display in a list view.
    /// </summary>
    public class ListViewProcessTaskCompositeViewResult<T> : ProcessTaskCompositeViewResult
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public string SortBy { get; private set; }
        public bool Ascending { get; private set; }

        public ListViewProcessTaskCompositeViewResult(ProcessTaskViewResult child, int page, int pageSize, string sortBy, bool ascending)
            : base(child)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            Ascending = ascending;
        }

        protected override void Task()
        {
            ViewResult viewResult = GetRootViewResult();

            // Convert the enumerable model in the base view to a listviewmodel
            IEnumerable<T> list = (viewResult.ViewData.Model as IEnumerable<T>);

            if (list != null)
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