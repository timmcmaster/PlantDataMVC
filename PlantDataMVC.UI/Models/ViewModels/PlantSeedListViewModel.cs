using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
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
