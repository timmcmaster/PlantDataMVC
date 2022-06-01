﻿using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels;
using PlantDataMVC.UICore.Models.ViewModels.SaleEvent;

namespace PlantDataMVC.UICore.Controllers.Queries.SaleEvent
{
    public class IndexQuery : IQuery<ListViewModelStatic<SaleEventListViewModel>>
    {
        public IndexQuery(int page, int pageSize, string sortBy, bool sortAscending)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
            SortAscending = sortAscending;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
    }
}