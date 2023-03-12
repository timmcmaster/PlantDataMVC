using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.Plant
{
    public class PlantListViewModel
    {
        [HiddenInput(DisplayValue = false)]
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
    }
}