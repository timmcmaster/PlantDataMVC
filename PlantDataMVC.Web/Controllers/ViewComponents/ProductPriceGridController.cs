using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.ProductPrice;
using PlantDataMVC.Web.Models.EditModels.ProductPrice;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.PriceListType;
using Syncfusion.EJ2.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    public class ProductPriceGridController : Controller
    {
        private readonly IMediator _mediator;

        public ProductPriceGridController(IMediator mediator)
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

        public async Task<ActionResult> Insert([FromBody] CRUDModel<ProductPriceCreateEditModel> x)
        {
            // TODO: won't be correct, as we can't select the parent genus from the grid
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Update([FromBody] CRUDModel<ProductPriceUpdateEditModel> x)
        {
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<ProductPriceDestroyEditModel> x)
        {
            var id = Convert.ToInt32(x.Key.ToString());
            var form = new ProductPriceDestroyEditModel() { Id = id };
            
            var result = await _mediator.Send(form);

            return Json(form);
        }

        [HttpPost]
        public IActionResult GetGridViewComponent([FromBody] PriceListTypeDetailsViewModel model)
        {
            if (model != null)
            {
                return ViewComponent("ProductPriceGrid", new { productPrices = model.ProductPrices, effectiveDate = model.SelectedEffectiveDate, gridOptions = model.GridOptions, priceListTypeId = model.Id });
            }

            return View();
        }

        [HttpPost]
        public IActionResult GetGridPartial([FromBody] PriceListTypeDetailsViewModel model)
        {
            if (model != null)
            {
                return PartialView("_ProductPriceGridPartial", new ProductPriceGridViewModel { Items = model.ProductPrices, EffectiveDate = model.SelectedEffectiveDate, Options = model.GridOptions, PriceListTypeId = model.Id });
            }

            return View();
        }

    }
}
