using System.ComponentModel.DataAnnotations;


namespace PlantData.Web.Blazor.UIModels.ViewModels.Label
{
    public class PlantLabelGridModel
    {
        [Display(Name = "Species Name")]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Label Qty")]
        public int LabelQuantity { get; set; }


        public PlantLabelGridModel()
        {
        }
    }
}
