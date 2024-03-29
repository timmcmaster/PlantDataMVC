﻿using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Framework.Web.Mediator;
using PlantDataMVC.UI.Controllers.Queries.Genus;
using PlantDataMVC.UI.Models.EditModels.Genus;
using PlantDataMVC.UI.Models.ViewModels.Genus;
using Thinktecture.IdentityModel.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class GenusController : DefaultController
    {
        private readonly IMediator _mediator;

        public GenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        [ResourceAuthorize("Read", "Genus")]
        public async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var query = new IndexQuery(localPage,localPageSize, localSortBy, localAscending);
            var model = await _mediator.Request(query);

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
        [ResourceAuthorize("Read", "Genus")]
        public async Task<ActionResult> Show(int id)
        {
            var query = new ShowQuery(id);
            var model = await _mediator.Request(query);

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
        [ResourceAuthorize("Write", "Genus")]
        public ActionResult New()
        {
            var item = new GenusNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GenusCreateEditModel form)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // Display prior to POST via Update 
        [ResourceAuthorize("Write", "Genus")]
        public async Task<ActionResult> Edit(int id)
        {
            var query = new EditQuery(id);
            var model = await _mediator.Request(query);

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
        public async Task<ActionResult> Update(GenusUpdateEditModel form)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Show", new { id = form.Id });

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // GET: /"ControllerName"/Delete/5
        [ResourceAuthorize("Write", "Genus")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new DeleteQuery(id);
            var model = await _mediator.Request(query);

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
        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(GenusDestroyEditModel form)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }
    }
}
