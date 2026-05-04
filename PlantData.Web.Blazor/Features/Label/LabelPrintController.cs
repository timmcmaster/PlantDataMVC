using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlantData.Web.Blazor.Features.Plant;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.EditModels.Label;
using PlantData.Web.Blazor.UIModels.ViewModels.Label;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Labels
{
    public class LabelPrintController : Controller
    {
        private readonly IMediator _mediator;

        public LabelPrintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: /"ControllerName"/BarcodesPrint
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BarcodesPrint(BarcodeLabelsEditModel form, string labelData)
        {
            var failureResult = DefaultFormFailureResult();

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;

            }

            if (labelData != null)
            {
                form.Items = JsonConvert.DeserializeObject<IEnumerable<BarcodeLabelListEditModel>>(labelData);
            }

            var result = await _mediator.Send(form);

            var reportBytes = Convert.FromBase64String(result);

            var fileModel = new FileModel()
            {
                Name = $"BarcodeLabels-{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                ContentType = "application/pdf",
                Data = reportBytes,
                DataBase64 = result
            };
            //var successResult = RedirectToAction("ViewPdf", PlantDataMvcAppControllers.Label);
            var successResult = View("ViewPdf", fileModel);

            return string.IsNullOrEmpty(result) ? failureResult : successResult;
        }

        protected ActionResult DefaultFormFailureResult()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
