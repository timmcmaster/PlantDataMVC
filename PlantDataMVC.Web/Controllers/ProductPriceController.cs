using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Controllers.Queries.ProductPrice;
using PlantDataMVC.Web.Models.EditModels.ProductPrice;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    public class ProductPriceController : DefaultController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductPriceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
                model.GridOptions = new GridOptionsModel()
                {
                    AllowAdd = false,
                    AllowDelete = false,
                    AllowEdit = false,
                    AllowPaging = false,
                    AllowSorting = false,
                };

                return View(model);
            }
        }

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

        // GET: /"ControllerName"/New
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> New(int? priceListTypeId)
        {
            if (priceListTypeId.HasValue)
            {
                var query = new PlantDataMVC.Web.Controllers.Queries.PriceListType.ShowQuery(priceListTypeId.Value);
                var priceListModel = await _mediator.Send(query);

                var item = new ProductPriceDataModel { PriceListTypeId = priceListTypeId.Value, PriceListTypeName = priceListModel.Name };

                var model = _mapper.Map<ProductPriceDataModel, ProductPriceNewViewModel>(item);

                return View(model);
            }
            else
            {
                var item = new ProductPriceDataModel();
                return View(item);
            }
        }

        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductPriceCreateEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", PlantDataMvcAppControllers.PriceListType, new { id = form.PriceListTypeId });

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

        // POST: /"ControllerName"/Update
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(ProductPriceUpdateEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

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

        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(ProductPriceDestroyEditModel form)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst("unique_user_key").Value;

            // TODO: Use userId in submit of form (via mediator)

            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Index");
            //var successResult = RedirectToAction("Details", PlantDataMvcAppControllers.PriceListType, new { id = form.PriceListTypeId });

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
