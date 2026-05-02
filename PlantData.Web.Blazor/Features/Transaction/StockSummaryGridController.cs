using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantData.Web.Blazor.Features.Transaction;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Controllers.ViewComponents
{
    public class StockSummaryGridController : Controller
    {
        private readonly IMediator _mediator;

        public StockSummaryGridController(IMediator mediator)
        {
            _mediator = mediator;
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

            var query = new StockSummaryQuery(localPage, localPageSize, localSortBy, localAscending);
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
    }
}
