//using Framework.Web.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.Genus;
using PlantDataMVC.Web.Models.EditModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> UrlDatasource([FromBody]DataManagerRequest request, int? page, int? pageSize, string? sortBy, bool? ascending)
        {

            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            // Convert operation to appropriate api call ?
            //var localPage = request.Skip != 0 ? request.Skip / request.Take : 1;
            //var localPageSize = request.Take != 0 ? request.Take : 20;
            //var localSortBy = string.Empty;
            //var localAscending = true;

            var query = new IndexQuery(localPage, localPageSize, localSortBy, localAscending);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                var jsonResult = request.RequiresCounts ? Json(new { result = model, count = model.Count }) : Json(model);

                return jsonResult;
            }
        }

        public async Task<ActionResult> Insert([FromBody] ICRUDModel<GenusCreateEditModel> x)
        {
            var form = x.value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Update([FromBody] ICRUDModel<GenusUpdateEditModel> x)
        {
            var form = x.value;

            var result = await _mediator.Send(form);

            return Json(form);
        }

        public async Task<ActionResult> Delete([FromBody] ICRUDModel<GenusListViewModel> x)
        {
            var id = Convert.ToInt32(x.key.ToString());
            var form = new GenusDestroyEditModel() { Id = id };
            
            var result = await _mediator.Send(form);

            return Json(form);
        }

        public class ICRUDModel<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public object key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }
    }
}
