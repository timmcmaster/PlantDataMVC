using Framework.Web.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Common.List;

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
