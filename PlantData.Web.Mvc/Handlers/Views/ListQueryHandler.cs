using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Views;
using PlantData.Web.Mvc.Controllers.Queries;

namespace PlantData.Web.Mvc.Handlers.Views
{
    public abstract class ListQueryHandler<TItem> : IQueryHandler<ListQuery<TItem>, IEnumerable<TItem>>
    {
        public abstract Task<IEnumerable<TItem>> Handle(ListQuery<TItem> query, CancellationToken cancellationToken);
    }
}