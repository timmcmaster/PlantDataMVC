using System.Collections.Generic;
using Framework.Web.Core.Views;

namespace PlantDataMVC.UICore.Controllers.Queries
{
    /// <summary>
    /// Generic query, currently used for dropdown lists
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="IQueryForList{TListItem,TViewModel}.Collections.Generic.IEnumerable{TItem}}" />
    public class ListQuery<TItem> : IQueryForList<TItem, IEnumerable<TItem>>
    {
    }
}