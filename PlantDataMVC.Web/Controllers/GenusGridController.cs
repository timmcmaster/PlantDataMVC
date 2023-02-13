//using Framework.Web.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using PlantDataMVC.Web.Controllers.Queries.Genus;
using PlantDataMVC.Web.Models.EditModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Collections.Generic;

namespace PlantDataMVC.Web.Controllers
{
    public class GenusGridController : DefaultController
    {
        private readonly IMediator _mediator;

        public GenusGridController(IMediator mediator)
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
        public async Task<ActionResult> UrlDatasource([FromBody]DataManagerRequest request)
        {

            // Convert operation to appropriate api call
            var localPage = request.Skip != 0 ? (request.Skip / request.Take) + 1 : 1;
            var localPageSize = request.Take != 0 ? request.Take : 20;

            var firstSort = request.Sorted?.FirstOrDefault(); 
            var localSortBy = firstSort == null ? String.Empty : firstSort.Name;
            var localAscending = firstSort == null ? true : firstSort.Direction == "ascending";

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

        public async Task<ActionResult> Insert([FromBody] CRUDModel<GenusCreateEditModel> x)
        {
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Update([FromBody] CRUDModel<GenusUpdateEditModel> x)
        {
            var form = x.Value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Delete([FromBody] CRUDModel<GenusDestroyEditModel> x)
        {
            var id = Convert.ToInt32(x.Key.ToString());
            var form = new GenusDestroyEditModel() { Id = id };
            
            var result = await _mediator.Send(form);

            return Json(form);
        }
    }
}
