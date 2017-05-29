using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.UI.Helpers
{
    public interface ISortable
    {
        string SortBy { get; set; }
        bool SortAscending { get; set; }
        string SortExpression { get; }
    }
}
