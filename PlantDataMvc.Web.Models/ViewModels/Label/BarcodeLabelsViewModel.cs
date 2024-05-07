using PlantDataMVC.Web.Models.ViewComponents.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.Label
{
    public class BarcodeLabelsViewModel
    {
        [Display(Name = "Layout Name")]
        public string LayoutName { get; set; } = string.Empty;

        [Display(Name = "Barcode Labels")]
        public IEnumerable<BarcodeLabelListViewModel> BarcodeLabels { get; set; } = new List<BarcodeLabelListViewModel>();

        public GridOptionsModel GridOptions { get; set; } = new();

    }
}
