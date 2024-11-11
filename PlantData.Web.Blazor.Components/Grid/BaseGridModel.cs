using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class BaseGridModel<T> : IBaseGridModel<T>
    {
        public GridOptionsModel Options { get; set; }
        public GridPagingModel Paging { get; set; }
        public GridSortingModel Sorting { get; set; }
        public GridLinksModel Links { get; set; }

        public IEnumerable<T> Items { get; set; } = new List<T>();
        public IEnumerable<string> PropertyColumns { get; set; } = new List<string>();
    }
}
