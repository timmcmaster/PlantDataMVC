using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Blazor.UIModels.ViewModels.Label
{
    public class BarcodeLabelGridModel
    {
        [Display(Name = "Price Record")]
        public int ProductPriceId { get; set; }

        [Display(Name = "Price Record")]
        public string ProductPriceText { get; private set; }

        [Display(Name = "Label Qty")]
        public int LabelQuantity { get; set; }

        public BarcodeLabelGridModel()
        {
        }
    }
}
