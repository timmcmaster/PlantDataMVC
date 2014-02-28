using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMvc3.Core.Domain.BusinessObjects;

namespace PlantDataMvc3.UI.Models
{
    public class PlantShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Genus { get; set; }
        
        public string Species { get; set; }
        
        [Display(Name = "Latin Name")]
        public string LatinName { get; set; }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Propagation Time")]
        public int PropagationTime { get; set; }
        
        public bool Native { get; set; }
        
        public IList<PlantSeedListViewModel> Seeds { get; set; }
        
        public IList<PlantStockEntryListViewModel> Stock { get; set; }

        //public PlantShowViewModel()
        //    : this("", "", "", "", 0, true)
        //{
        //    Seeds = new List<PlantSeedListViewModel>();
        //    Stock = new List<PlantStockEntryListViewModel>();
        //}

        //public PlantShowViewModel(string genus, string species, string commonName, string description, int propagationTime, bool native)
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