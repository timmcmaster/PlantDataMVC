using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Web.Controllers.Queries.SaleEventStock;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels.SaleEventStock;
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
    }
}
