using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Web.Controllers.Queries.SaleEvent;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.EditModels.SaleEvent;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    // TODO: Use userId in posts having ValidateAntiForgeryToken (as per GenusController)

    public class SaleEventController : DefaultController
    {
        private readonly IMediator _mediator;

        public SaleEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var query = new IndexQuery(localPage, localPageSize, localSortBy, localAscending);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        // GET: /"ControllerName"/Details/5
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Details(int id)
        {
            var query = new DetailsQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /"ControllerName"/Show/5
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Show(int id)
        {
            var query = new ShowQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /"ControllerName"/New
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public ActionResult New()
        {
            var item = new SaleEventNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaleEventCreateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // GET: /"ControllerName"/Edit/5
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Edit(int id)
        {
            var query = new EditQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(SaleEventUpdateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Show", new { id = form.Id }); ;

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // GET: /"ControllerName"/Delete/5
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new DeleteQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // POST: /Seed/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(SaleEventDestroyEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Index");

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
