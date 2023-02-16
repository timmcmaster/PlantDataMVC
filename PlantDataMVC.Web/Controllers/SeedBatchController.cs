using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Web.Controllers.Queries.SeedBatch;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.EditModels.SeedBatch;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    // TODO: Use userId in posts having ValidateAntiForgeryToken (as per GenusController)

    public class SeedBatchController : DefaultController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SeedBatchController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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

        public async Task<ActionResult> IndexVC(int? page, int? pageSize, string sortBy, bool? ascending)
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
            var item = new SeedBatchNewViewModel();
            return View(item);
        }

        /// <summary>
        /// Additional action for creating a new entry for a given species.
        /// </summary>
        /// <param name="speciesId">The Id of the species.</param>
        /// <returns></returns>
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        [RequireRequestValue("speciesId")]
        public ActionResult New(int speciesId)
        {
            var item = new SeedBatchDataModel { SpeciesId = speciesId };
            var model = _mapper.Map<SeedBatchDataModel, SeedBatchNewViewModel>(item);
            return View(model);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SeedBatchCreateEditModel form)
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
        public async Task<ActionResult> Update(SeedBatchUpdateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Show", new { id = form.Id });

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
        public async Task<ActionResult> Destroy(SeedBatchDestroyEditModel form)
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
