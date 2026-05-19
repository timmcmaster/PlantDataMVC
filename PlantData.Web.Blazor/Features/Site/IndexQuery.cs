using Framework.Web.Views;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.Site;

namespace PlantData.Web.Blazor.Features.Site;

public class IndexQuery : IQuery<GridDataModel<SiteGridModel>>
{
    public IndexQuery(int? page, int? pageSize, string sortBy, bool sortAscending)
    {
        Page = page;
        PageSize = pageSize;
        SortBy = sortBy;
        SortAscending = sortAscending;
    }

    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string SortBy { get; set; }
    public bool SortAscending { get; set; }
}