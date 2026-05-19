using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantData.Web.Blazor.UIModels.EditModels.PriceListType;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.PriceListType;

public class PriceListTypeGridController : Controller
{
    private readonly IMediator _mediator;
    private readonly IPriceListTypeLookupService _priceListTypeLookupService;

    public PriceListTypeGridController(IMediator mediator, IPriceListTypeLookupService priceListTypeLookupService)
    {
        _mediator = mediator;
        this._priceListTypeLookupService = priceListTypeLookupService;
    }

    [HttpPost]
    [Route("data/[controller]")]
    public async Task<ActionResult> Post([FromBody] DataManagerRequest request, bool allowPaging)
    {
        // Convert operation to appropriate api call
        int? localPage = request.Skip != 0 ? request.Skip / request.Take + 1 : 1;
        int? localPageSize = request.Take != 0 ? request.Take : 20;

        var firstSort = request.Sorted?.FirstOrDefault();
        var localSortBy = firstSort == null ? string.Empty : firstSort.Name;
        var localAscending = firstSort == null ? true : firstSort.Direction == "ascending";

        if (!allowPaging)
        {
            localPage = null;
            localPageSize = null;
        }

        var query = new IndexQuery(localPage, localPageSize, localSortBy, localAscending);
        var model = await _mediator.Send(query);

        if (model == null)
        {
            return Content("An error occurred");
        }
        else
        {
            var jsonResult = request.RequiresCounts ? Json(new { result = model, count = model.TotalCount }) : Json(model);

            return jsonResult;
        }
    }

    [HttpPost]
    [Route("data/[controller]/Insert")]
    public async Task<ActionResult> Insert([FromBody] CRUDModel<PriceListTypeCreateEditModel> x)
    {
        var form = x.Value;

        var result = await _mediator.Send(form);

        return Json(form);
    }

    [HttpPost]
    [Route("data/[controller]/Update")]
    public async Task<ActionResult> Update([FromBody] CRUDModel<PriceListTypeUpdateEditModel> x)
    {
        var form = x.Value;

        var result = await _mediator.Send(form);

        return Json(form);
    }

    [HttpPost]
    [Route("data/[controller]/Delete")]
    public async Task<ActionResult> Delete([FromBody] CRUDModel<PriceListTypeDestroyEditModel> x)
    {
        var id = Convert.ToInt32(x.Key.ToString());
        var form = new PriceListTypeDestroyEditModel() { Id = id };

        var result = await _mediator.Send(form);

        return Json(form);
    }

    [HttpPost]
    [Route("data/[controller]/List")]
    public async Task<ActionResult> List([FromBody] DataManagerRequest request)
    {
        var dataSource = await _priceListTypeLookupService.GetData();

        if (request.Where != null && request.Where.Count > 0)
        {
            // Filtering
            dataSource = DataOperations.PerformFiltering(dataSource, request.Where, request.Where[0].Condition);
        }

        var jsonResult = request.RequiresCounts ? Json(new { result = dataSource, count = dataSource.Count() }) : Json(dataSource);

        return jsonResult;
    }
}
