using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Models.EditModels.Label;
using PlantDataMVC.Web.Models.EditModels.Transaction;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    public class LabelController : DefaultController
    {
        private readonly IMediator _mediator;

        public LabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/StockSummary
        // GET: /"ControllerName"/StockSummary?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Plants(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            var gridOptions = new GridOptionsModel()
            {
                AllowAdd = true,
                AllowDelete = false,
                AllowEdit = true,
                AllowPaging = false,
                AllowSorting = true
            };

            // resolve parameters
            int? localPage = page ?? 1;
            int? localPageSize = pageSize ?? 20;
            string localSortBy = sortBy ?? string.Empty;
            bool localAscending = ascending ?? true;

            if (!gridOptions.AllowPaging)
            {
                localPage = null;
                localPageSize = null;
            }

            var query = new PlantLabelQuery(localPage, localPageSize, localSortBy, localAscending);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                model.GridOptions = gridOptions;

                return View(model);
            }
        }

        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlantsPrint(PlantLabelGridEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("xxxx", @PlantDataMvcAppControllers.Label);

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

    }
}
