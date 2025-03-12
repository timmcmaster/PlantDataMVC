using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantData.Web.Blazor.UIModels.EditModels.Plant;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Plant
{
    public class PlantGridController : Controller
    {
        private readonly IMediator _mediator;

        public PlantGridController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<ActionResult> Insert([FromBody] CRUDModel<PlantCreateEditModel> x)
        {
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        [HttpPost]
        [Route("data/[controller]/Update")]
        public async Task<ActionResult> Update([FromBody] CRUDModel<PlantUpdateEditModel> x)
        {
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        [HttpPost]
        [Route("data/[controller]/Delete")]
        public async Task<ActionResult> Delete([FromBody] CRUDModel<PlantDestroyEditModel> x)
        {
            var id = Convert.ToInt32(x.Key.ToString());
            var form = new PlantDestroyEditModel() { Id = id };

            var result = await _mediator.Send(form);

            return Json(form);
        }
    }
}
