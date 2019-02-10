using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;

namespace PlantDataMVC.UI.Handlers.Views
{
    public abstract class ListQueryHandler<TItem> : IQueryHandler<ListQuery<TItem>, IEnumerable<TItem>>
    {
        public abstract Task<IEnumerable<TItem>> HandleAsync(ListQuery<TItem> query);
    }
}