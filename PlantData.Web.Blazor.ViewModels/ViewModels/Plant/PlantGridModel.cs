using System.ComponentModel.DataAnnotations;

namespace PlantData.Web.Blazor.UIModels.ViewModels.Plant
{
    public class PlantGridModel
    {
        public int Id { get; set; }

        [Display(Name = "Latin Name")]
        public string Binomial { get; set; }

        public int GenusId { get; set; }

        public string Genus { get; set; }

        public string Species { get; set; }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }

        [Display(Name = "Native")]
        public bool Native { get; set; }

        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int? PropagationTime { get; set; }
    }
}