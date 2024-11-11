using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public interface IBaseGridModel<T>
    {
        GridOptionsModel Options { get; set; }
        GridPagingModel Paging { get; set; }
        GridSortingModel Sorting { get; set; }
        GridLinksModel Links { get; set; }

        IEnumerable<T> Items { get; set; }
        IEnumerable<string> PropertyColumns { get; set; }
    }
}
