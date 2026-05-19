using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantData.Web.Blazor.Features.Plant;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.Label;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Labels;

public class PlantLabelRequestGridController : Controller
{
    public static List<PlantLabelRequestGridModel> PlantLabelRequests { get; set; } = new List<PlantLabelRequestGridModel>();

    private readonly IMediator _mediator;
    private readonly ISpeciesLookupService _speciesLookupService;

    public PlantLabelRequestGridController(IMediator mediator, ISpeciesLookupService speciesLookupService)
    {
        _mediator = mediator;
        _speciesLookupService = speciesLookupService;
    }

    [HttpPost]
    [Route("data/[controller]")]
    public async Task<ActionResult> Post([FromBody] DataManagerRequest request)
    {
        int? localPage = request.Skip != 0 ? request.Skip / request.Take + 1 : 1;
        int? localPageSize = request.Take != 0 ? request.Take : 20;

        var firstSort = request.Sorted?.FirstOrDefault();
        var localSortBy = firstSort == null ? string.Empty : firstSort.Name;
        var localAscending = firstSort == null ? true : firstSort.Direction == "ascending";

        var allowPaging = request.Params is null ? false : ((JsonElement)request.Params["allowPaging"]).GetBoolean();

        if (!allowPaging)
        {
            localPage = null;
            localPageSize = null;
        }

        var model = new GridDataModel<PlantLabelRequestGridModel>(PlantLabelRequests, localPage ?? 1, localPageSize ?? PlantLabelRequests.Count(), PlantLabelRequests.Count(), localSortBy, localAscending);

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
    public async Task<ActionResult> Insert([FromBody] CRUDModel<PlantLabelRequestGridModel> x)
    {
        var form = x.Value;

        PlantLabelRequests.Insert(0, form);

        return Json(form);
    }

    [HttpPost]
    [Route("data/[controller]/Update")]
    public async Task<ActionResult> Update([FromBody] CRUDModel<PlantLabelRequestGridModel> x)
    {
        var form = x.Value;

        var data = PlantLabelRequests.Where(r => r.SpeciesId == form.SpeciesId).FirstOrDefault();
        if (data != null)
        {
            data.SpeciesId = form.SpeciesId;
            data.LabelQuantity = form.LabelQuantity;
        }

        return Json(form);
    }

    [HttpPost]
    [Route("data/[controller]/Delete")]
    public async Task<ActionResult> Delete([FromBody] CRUDModel<PlantLabelRequestGridModel> x)
    {
        var id = Convert.ToInt32(x.Key.ToString());

        PlantLabelRequests.Remove(PlantLabelRequests.Where(r => r.SpeciesId == id).FirstOrDefault());

        return Json(x.Value);
    }
}
