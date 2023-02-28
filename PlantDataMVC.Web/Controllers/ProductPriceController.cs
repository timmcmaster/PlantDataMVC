using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.ProductPrice;
using PlantDataMVC.Web.Helpers;
using System.Threading.Tasks;
using PlantDataMVC.Web.Models.EditModels.ProductPrice;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System.Security.Claims;
using PlantDataMVC.Web.Shared.Components.PriceListTypeGrid;
using PlantDataMVC.Web.Shared.Components.ProductTypeGrid;
using System;

namespace PlantDataMVC.Web.Controllers
{
    public class ProductPriceController : DefaultController
    {
        private readonly IMediator _mediator;

        public ProductPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=ProductPrice&ascending=True
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

        // GET: /"ControllerName"/Show/5
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Show(int productTypeId, int priceListTypeId, DateTime dateEffective)
        {
            var query = new ShowQuery(productTypeId, priceListTypeId, dateEffective);
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

        // GET: /"ControllerName"/New
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public ActionResult New()
        {
            var item = new ProductPriceNewViewModel();
            return View(item);
        }

        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductPriceCreateEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

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

        // Display prior to POST via Update 
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Edit(int productTypeId, int priceListTypeId, DateTime dateEffective)
        {
            var query = new EditQuery(productTypeId, priceListTypeId, dateEffective);
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

        // POST: /"ControllerName"/Update
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(ProductPriceUpdateEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Show", new { productTypeId = form.ProductTypeId, priceListTypeId = form.PriceListTypeId, dateEffective = form.DateEffective.ToString("yyyyMMdd") });

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        // GET: /"ControllerName"/Delete/5
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Delete(int productTypeId, int priceListTypeId, DateTime dateEffective)
        {
            var query = new DeleteQuery(productTypeId, priceListTypeId, dateEffective);
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

        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(ProductPriceDestroyEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

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
