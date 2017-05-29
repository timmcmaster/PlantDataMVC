using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantNewViewModel
    {
        [Required, StringLength(30), DataType("CustomString")]
        public string Genus { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Species { get; set; }

        [Display(Name = "Common Name"), StringLength(50), DataType("CustomString")]
        public string CommonName { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }

        public bool Native { get; set; }

        //public PlantNewViewModel()
        //    : this("", "", "", "", 0, true)
        //{
        //}

        //public PlantNewViewModel(string genus, string species, string commonName, string description, int propagationTime, bool native)
        //{
        //    Genus = genus;
        //    Species = species;
        //    CommonName = commonName;
        //    Description = description;
        //    PropagationTime = propagationTime;
        //    Native = native;
        //}
    }
}