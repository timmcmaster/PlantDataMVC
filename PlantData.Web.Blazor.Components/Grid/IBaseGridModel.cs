using System.Collections.Generic;
using PlantData.Web.Blazor.SharedComponents.Paging;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public interface IBaseGridModel<T>
    {
        GridOptionsModel Options { get; set; }
        PagingModel Paging { get; set; }
        GridSortingModel Sorting { get; set; }
        GridLinksModel Links { get; set; }

        IEnumerable<T> Items { get; set; }
        GridUrlDataSourceModel UrlDataSource { get; set; }
    }
}
