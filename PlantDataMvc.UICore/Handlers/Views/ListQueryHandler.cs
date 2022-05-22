using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Controllers.Queries;

namespace PlantDataMVC.UICore.Handlers.Views
{
    public abstract class ListQueryHandler<TItem> : IQueryHandler<ListQuery<TItem>, IEnumerable<TItem>>
    {
        public abstract Task<IEnumerable<TItem>> Handle(ListQuery<TItem> query, CancellationToken cancellationToken);
    }
}