using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Genus { get; set; }
        
        public string Species { get; set; }
        
        [Display(Name = "Latin Name")]
        public string Binomial { get; set; }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }
        
        public bool Native { get; set; }
            }
}