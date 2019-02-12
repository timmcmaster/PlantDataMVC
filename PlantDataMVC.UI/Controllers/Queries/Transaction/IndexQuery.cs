﻿using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Transaction;

namespace PlantDataMVC.UI.Controllers.Queries.Transaction
{
    public class IndexQuery : IQuery<ListViewModelStatic<PlantStockTransactionListViewModel>>
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