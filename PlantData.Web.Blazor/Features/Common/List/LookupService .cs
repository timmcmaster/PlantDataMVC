using Framework.Web.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Common.List
{
    public abstract class LookupService<TItem> : ILookupService<TItem> where TItem : class
    {
        private IMediator _mediator;

        public LookupService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<TItem> GetData()
        {
            var query = new ListQuery<TItem>();

            var requestTask = _mediator.Send(query);

            //// NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            //// ALSO, lose any exception type management, as it returns AggregateException
            var dataModelItems = requestTask.Result;

            return dataModelItems;
        }

        public IEnumerable<TItem> GetOrderedData(Func<TItem, string> displayValueSelector)
        {
            var orderedData = GetData().OrderBy(x => displayValueSelector(x));

            return orderedData;
        }
    }

    public abstract class LookupServiceAsync<TItem> : ILookupServiceAsync<TItem> where TItem : class
    {
        private IMediator _mediator;

        public LookupServiceAsync(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<TItem>> GetData()
        {
            var query = new ListQuery<TItem>();

            var dataModelItems = await _mediator.Send(query);

            return dataModelItems;
        }

        public async Task<IEnumerable<TItem>> GetOrderedData(Func<TItem, string> displayValueSelector)
        {
            var data = await GetData();
            var orderedData = data.OrderBy(x => displayValueSelector(x));

            return orderedData;
        }
    }
}
