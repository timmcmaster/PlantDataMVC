using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.UI.Helpers
{
    public interface IPageable
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }

        bool HasPreviousPage { get;}
        bool HasNextPage {get;}
    }
}
