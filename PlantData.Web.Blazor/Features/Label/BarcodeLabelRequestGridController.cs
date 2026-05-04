using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantData.Web.Blazor.Features.Plant;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.EditModels.Label;
using PlantData.Web.Blazor.UIModels.ViewModels.Label;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Labels
{
    public class BarcodeLabelRequestGridController : Controller
    {
        public static List<BarcodeLabelRequestGridModel> BarcodeLabelRequests { get; set; } = new List<BarcodeLabelRequestGridModel>();

        private readonly IMediator _mediator;
        private readonly ISpeciesLookupService _speciesLookupService;

        public BarcodeLabelRequestGridController(IMediator mediator, ISpeciesLookupService speciesLookupService)
        {
            _mediator = mediator;
            _speciesLookupService = speciesLookupService;
        }

        [HttpPost]
        [Route("data/[controller]")]
        public async Task<ActionResult> Post([FromBody] DataManagerRequest request)
        {

            // Convert operation to appropriate api call
            int? localPage = request.Skip != 0 ? request.Skip / request.Take + 1 : 1;
            int? localPageSize = request.Take != 0 ? request.Take : 20;

            var firstSort = request.Sorted?.FirstOrDefault();
            var localSortBy = firstSort == null ? string.Empty : firstSort.Name;
            var localAscending = firstSort == null ? true : firstSort.Direction == "ascending";

            var allowPaging = ((JsonElement)request.Params["allowPaging"]).GetBoolean();

            if (!allowPaging)
            {
                localPage = null;
                localPageSize = null;
            }


            var model = new GridDataModel<BarcodeLabelRequestGridModel>(BarcodeLabelRequests, localPage ?? 1, localPageSize ?? BarcodeLabelRequests.Count(), BarcodeLabelRequests.Count(), localSortBy, localAscending);

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
        public async Task<ActionResult> Insert([FromBody] CRUDModel<BarcodeLabelRequestGridModel> x)
        {
            var form = x.Value;

            BarcodeLabelRequests.Insert(0, form);

            return Json(form);
        }

        [HttpPost]
        [Route("data/[controller]/Update")]
        public async Task<ActionResult> Update([FromBody] CRUDModel<BarcodeLabelRequestGridModel> x)
        {
            var form = x.Value;

            // TODO: get/define proper key value
            var data = BarcodeLabelRequests.Where(r => r.ProductPriceId == form.ProductPriceId).FirstOrDefault();
            if (data != null)
            {
                data.ProductPriceId = form.ProductPriceId;
                data.LabelQuantity = form.LabelQuantity;
            }

            return Json(form);
        }

        [HttpPost]
        [Route("data/[controller]/Delete")]
        public async Task<ActionResult> Delete([FromBody] CRUDModel<BarcodeLabelRequestGridModel> x)
        {
            var id = Convert.ToInt32(x.Key.ToString());

            BarcodeLabelRequests.Remove(BarcodeLabelRequests.Where(r => r.ProductPriceId == id).FirstOrDefault());

            return Json(x.Value);
        }
    }
}
