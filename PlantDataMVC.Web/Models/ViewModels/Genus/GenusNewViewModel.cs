using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UICore.Models.ViewModels.Genus
{
    public class GenusNewViewModel
    {
        [Display(Name = "Latin Name"), StringLength(30), DataType("CustomString")]
        public string LatinName { get; set; }
    }
}