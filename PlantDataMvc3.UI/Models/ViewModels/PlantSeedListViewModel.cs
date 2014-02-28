using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMvc3.Core.Domain.BusinessObjects;

namespace PlantDataMvc3.UI.Models
{
    public class PlantSeedListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        public string Location { get; set; }
    }
}
