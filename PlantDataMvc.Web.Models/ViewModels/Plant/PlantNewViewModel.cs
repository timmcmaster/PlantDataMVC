using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.Plant
{
    public class PlantNewViewModel
    {
        [Required, Display(Name = "Genus")]
        public int GenusId { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Species { get; set; }

        [Display(Name = "Common Name"), StringLength(50), DataType("CustomString")]
        public string CommonName { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }

        public bool Native { get; set; }
    }
}