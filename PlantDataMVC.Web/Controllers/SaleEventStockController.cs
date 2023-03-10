using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.SaleEventStock;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    // TODO: Use userId in posts having ValidateAntiForgeryToken (as per GenusController)

    public class SaleEventStockController : DefaultController
    {
        private readonly IMediator _mediator;

        public SaleEventStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            var gridOptions = new GridOptionsModel()
            {
                AllowAdd = false,
                AllowDelete = false,
                AllowEdit = false,
                AllowPaging = false,
                AllowSorting = false,
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

            var query = new IndexQuery(localPage, localPageSize, localSortBy, localAscending);
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
    }
}
