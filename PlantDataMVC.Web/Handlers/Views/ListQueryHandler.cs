using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Views;
using PlantDataMVC.Web.Controllers.Queries;

namespace PlantDataMVC.Web.Handlers.Views
{
    public abstract class ListQueryHandler<TItem> : IQueryHandler<ListQuery<TItem>, IEnumerable<TItem>>
    {
        public abstract Task<IEnumerable<TItem>> Handle(ListQuery<TItem> query, CancellationToken cancellationToken);
    }
}