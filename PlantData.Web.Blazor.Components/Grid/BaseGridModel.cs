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

        public IEnumerable<T> Items { get; set; } = new List<T>();
        public IEnumerable<BaseGridColumnModel<T>> Columns { get; set; } = new List<BaseGridColumnModel<T>>();
    }
}
