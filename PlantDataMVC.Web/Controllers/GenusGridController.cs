//using Framework.Web.Mediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Controllers.Queries.Genus;
using PlantDataMVC.Web.Helpers;
using System.Threading.Tasks;
using PlantDataMVC.Web.Models.EditModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using System.Security.Claims;
using Syncfusion.EJ2.Base;
using System.Collections;
using Newtonsoft.Json;
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

        public IActionResult Default()
        {

            return View();
        }
        
        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> UrlDatasource([FromBody]DataManagerRequest request)
        {
            // resolve parameters
            var localPage = 1;
            var localPageSize = 20;
            var localSortBy = string.Empty;
            var localAscending = true;

            var query = new IndexQuery(localPage, localPageSize, localSortBy, localAscending);
            var model = await _mediator.Send(query);

            //if (model == null)
            //{
            //    return Content("An error occurred");
            //}
            //else
            //{
            //    return View(model);
            //}

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                //IEnumerable DataSource = model;

                var al = new ArrayList 
                {
                 new { ID = 1, LatinName = "Abrophyllum" },
                 new { ID = 2, LatinName = "Acacia" },
                 new { ID = 3, LatinName = "Acmella" },
                 new { ID = 4, LatinName = "Acmena" },
                 new { ID = 5, LatinName = "Agathis" }
                };

                int count = al.Count;

                IEnumerable DataSource = al;

                DataOperations operation = new DataOperations();
                if (request.Skip != 0)
                {
                    DataSource = operation.PerformSkip(DataSource, request.Skip);   //Paging
                }
                if (request.Take != 0)
                {
                    DataSource = operation.PerformTake(DataSource, request.Take);
                }
                var jsonResult = request.RequiresCounts ? Json(new { Result = DataSource, Count = count }) : Json(DataSource);
                //var jsonResult = Json(DataSource);

                var jsonString = JsonConvert.SerializeObject(jsonResult.Value);

                return jsonResult;
            }
        }

    }
}
