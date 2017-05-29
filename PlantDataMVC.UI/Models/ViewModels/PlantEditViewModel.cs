using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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

        //public PlantEditViewModel()
        //    : this(0, "", "", "", "", 0, true)
        //{
        //}

        //public PlantEditViewModel(int id, string genus, string species, string commonName, string description, int propagationTime, bool native)
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