using MediatR;
using PlantData.Web.Blazor.UIModels.EditModels.Label;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace PlantData.Web.Blazor.UIModels.ViewModels.Label
{
    public class BarcodeLabelsViewModel
    {
        [Display(Name = "Layout Name"), Required]
        public string LayoutName { get; set; } = string.Empty;

        [Display(Name = "Barcode Labels"), Required]
        public IEnumerable<BarcodeLabelRequestGridModel> BarcodeLabelRequests { get; set; } = new List<BarcodeLabelRequestGridModel>();

        //public GridOptionsModel GridOptions { get; set; } = new();

        public async Task<FileModel> GetPdfLabelsReport(IMediator mediator, BarcodeLabelsEditModel form)
        {
            // Logic to generate or retrieve the PDF labels report.

            var result = await mediator.Send(form);

            var reportBytes = Convert.FromBase64String(result);

            var fileModel = new FileModel()
            {
                Name = $"BarcodeLabels-{DateTime.Now:yyyyMMdd_HHmm}.pdf",
                ContentType = "application/pdf",
                Data = reportBytes,
                DataBase64 = result
            };

            return fileModel;
        }
    }
}
