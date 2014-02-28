using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.UI.Helpers
{
    public interface ISortable
    {
        string SortBy { get; set; }
        bool SortAscending { get; set; }
        string SortExpression { get; }
    }
}
