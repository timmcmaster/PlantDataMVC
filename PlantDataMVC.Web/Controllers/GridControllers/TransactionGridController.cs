using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.Transaction;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    public class TransactionGridController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionGridController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult UrlAdaptor()
        {
            return View();
        }

        public IActionResult Default()
        {
            return View();
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> UrlDatasource([FromBody] DataManagerRequest request, bool allowPaging)
        {
            // Convert operation to appropriate api call
            int? localPage = request.Skip != 0 ? (request.Skip / request.Take) + 1 : 1;
            int? localPageSize = request.Take != 0 ? request.Take : 20;

            var firstSort = request.Sorted?.FirstOrDefault();
            var localSortBy = firstSort == null ? String.Empty : firstSort.Name;
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
    }
}
