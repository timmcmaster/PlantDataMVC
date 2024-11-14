using System;
using System.Linq.Expressions;

namespace PlantData.Web.Blazor.SharedComponents.Grid
{
    public class BaseGridColumnModel<T> : IBaseGridColumnModel<T>
    {
        // This is the unique identifier of the column
        public Guid Identifier { get; set; } = Guid.NewGuid();

        public string HeaderText { get; set; } = default!;

        public Expression<Func<T, object>> FieldExpression { get; set; }

        public string Format { get; set; } = default!;

        public bool IsPrimaryKey { get; set; }
    }
}
