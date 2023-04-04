using System.ComponentModel.DataAnnotations;


namespace PlantDataMVC.Web.Models.ViewModels.Label
{
    public class PlantLabelListViewModel
    {
        [Display(Name = "Species Name")]
        public int SpeciesId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Label Qty")]
        public int LabelQuantity { get; set; }


        public PlantLabelListViewModel()
        {
        }
    }
}
