using System.Collections.Generic;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Controllers.Queries
{
    /// <summary>
    /// Generic query, currently used for dropdown lists
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="Framework.Web.Views.IViewQueryForList{TItem, System.Collections.Generic.IEnumerable{TItem}}" />
    public class ListQuery<TItem> : IViewQueryForList<TItem, IEnumerable<TItem>>
    {
    }
}