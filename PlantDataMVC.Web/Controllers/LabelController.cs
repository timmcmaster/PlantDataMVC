using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlantDataMvc.Web.Models.ViewModels.Label;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Models.EditModels.Label;
using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    public class LabelController : DefaultController
    {
        private readonly IMediator _mediator;

        public LabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> Plants(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            var gridOptions = new GridOptionsModel()
            {
                AllowAdd = true,
                AllowDelete = false,
                AllowEdit = true,
                AllowPaging = false,
                AllowSorting = true
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

            var query = new PlantLabelQuery(localPage, localPageSize, localSortBy, localAscending);
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

        // POST: /"ControllerName"/PlantsPrint
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlantsPrint(string labelData)
        {
            var failureResult = DefaultFormFailureResult();

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }
            PlantLabelGridEditModel form = new PlantLabelGridEditModel();
            if (labelData != null)
            {
                form.Items = JsonConvert.DeserializeObject<IEnumerable<PlantLabelListEditModel>>(labelData);
            }

            var result = await _mediator.Send(form);

            var reportBytes = Convert.FromBase64String(result);

            var fileModel = new FileModel()
            {
                Name = "Test",
                ContentType = "application/pdf",
                Data = reportBytes,
                DataBase64 = result
            };
            //var successResult = RedirectToAction("ViewPdf", PlantDataMvcAppControllers.Label);
            var successResult = View("ViewPdf", fileModel);

            return string.IsNullOrEmpty(result) ? successResult : failureResult;
        }

        //// POST: /"ControllerName"/PlantsPrint
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> PlantsPrint([FromForm] PlantLabelGridEditModel form)
        //{
        //    var failureResult = DefaultFormFailureResult();

        //    if (!ModelState.IsValid)
        //    {
        //        // TODO: Display any model validation errors
        //        return failureResult;
        //    }

        //    var result = await _mediator.Send(form);

        //    var reportBytes = Convert.FromBase64String(result);

        //    var fileModel = new FileModel() 
        //    { 
        //        Name = "Test", 
        //        ContentType = "application/pdf", 
        //        Data = reportBytes 
        //    };
        //    //var successResult = RedirectToAction("ViewPdf", PlantDataMvcAppControllers.Label);
        //    var successResult = View("ViewPdf", fileModel);

        //    return string.IsNullOrEmpty(result) ? successResult : failureResult;
        //}

    }
}
