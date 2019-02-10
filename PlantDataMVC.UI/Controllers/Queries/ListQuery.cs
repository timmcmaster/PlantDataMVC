using System.Collections.Generic;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Controllers.Queries
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