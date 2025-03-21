using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Views;

namespace PlantData.Web.Blazor.Features.Common.List
{
    public abstract class ListQueryHandler<TItem> : IQueryHandler<ListQuery<TItem>, IEnumerable<TItem>>
    {
        public abstract Task<IEnumerable<TItem>> Handle(ListQuery<TItem> query, CancellationToken cancellationToken);
    }
}