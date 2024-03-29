﻿using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.Web.Controllers.Queries.SeedBatch
{
    public class IndexQuery : IQuery<ListViewModelStatic<SeedBatchListViewModel>>
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