using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Web.Controllers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Web.Services
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

            // NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            // ALSO, lose any exception type management, as it returns AggregateException
            var dataModelItems = requestTask.Result;

            return dataModelItems;
        }

        public IEnumerable<TItem> GetOrderedData(Func<TItem, string> displayValueSelector)
        {
            var orderedData = GetData().OrderBy(x => displayValueSelector(x));

            return orderedData;
        }
    }
}
