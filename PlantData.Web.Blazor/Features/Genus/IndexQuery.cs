using Framework.Web.Views;
using PlantData.Web.Blazor.UIModels.ViewModels.Genus;
using System.Collections.Generic;

namespace PlantData.Web.Blazor.Features.Genus
{
    public class IndexQuery : IQuery<List<GenusGridModel>>
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
}