﻿using System.Collections.Generic;
using PlantData.Web.Blazor.SharedComponents.Paging;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class BaseGridModel<T> : IBaseGridModel<T>
    {
        public GridOptionsModel Options { get; set; }
        public PagingModel Paging { get; set; }
        public GridSortingModel Sorting { get; set; }
        public GridLinksModel Links { get; set; }

        public GridUrlDataSourceModel UrlDataSource { get; set; }

        public GridDataModel<T> Items { get; set; }
    }
}
