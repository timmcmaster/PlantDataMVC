using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.Genus
{
    public class GenusGridModel
    {
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }
    }
}
