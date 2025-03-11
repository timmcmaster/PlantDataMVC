using System;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public interface IBaseGridColumnModel<T>
    {
        Guid Identifier { get; set; }
        string Format { get; set; }
        string HeaderText { get; set; }
        bool IsPrimaryKey { get; set; }
        bool IsVisible { get; set; }
    }
}