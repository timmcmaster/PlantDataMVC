using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.Label
{
    public class BarcodeLabelListViewModel
    {
        [Display(Name = "Price Record")]
        public int ProductPriceId { get; set; }

        [Display(Name = "Price Record")]
        public string ProductPriceText { get; private set; }

        [Display(Name = "Label Qty")]
        public int LabelQuantity { get; set; }

        public BarcodeLabelListViewModel()
        {
        }
    }
}
