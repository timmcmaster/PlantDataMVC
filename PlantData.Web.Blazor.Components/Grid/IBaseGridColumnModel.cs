using System;
using System.Linq.Expressions;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public interface IBaseGridColumnModel<T>
    {
        Guid Identifier { get; set; }
        string Format { get; set; }
        string HeaderText { get; set; }
        bool IsPrimaryKey { get; set; }
    }
}