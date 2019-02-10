using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models.ViewModels.Plant
{
    public class PlantDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        public string Genus { get; set; }
        
        public string Species { get; set; }

        [Display(Name = "Latin Name")]
        public string LatinName
        {
            get => string.Format("{0} {1}", Genus, Species);
        }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }

        public bool Native { get; set; }

        //public PlantDeleteViewModel()
        //    : this(0, "", "", "", "", 0, true)
        //{
        //}

        //public PlantDeleteViewModel(int id, string genus, string species, string commonName, string description, int propagationTime, bool native)
        //{
        //    Id = id;
        //    Genus = genus;
        //    Species = species;
        //    CommonName = commonName;
        //    Description = description;
        //    PropagationTime = propagationTime;
        //    Native = native;
        //}
    }
}