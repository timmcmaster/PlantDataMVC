using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Blazor.UIModels.ViewModels.Label
{
    public class BarcodeLabelsViewModel
    {
        [Display(Name = "Layout Name")]
        public string LayoutName { get; set; } = string.Empty;

        [Display(Name = "Barcode Labels")]
        public IEnumerable<BarcodeLabelRequestGridModel> BarcodeLabelRequests { get; set; } = new List<BarcodeLabelRequestGridModel>();

        //public GridOptionsModel GridOptions { get; set; } = new();

    }
}
