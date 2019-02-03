﻿using System;
using System.ComponentModel.DataAnnotations;
using Framework.Web.Views;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class PlantSeedNewViewModel : IViewModel
    {
        [Display(Name = "Species Name")]
        public SpeciesDto PlantSpecies { get; set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; set; }

        [StringLength(30), DataType("CustomString")]
        public string Location { get; set; }

        [StringLength(200), DataType("CustomString")]
        public string Notes { get; set; }

        [Display(Name = "Site Name")]
        public SiteDto Site { get; set; }

        public PlantSeedNewViewModel()
        {
            PlantSpecies = new SpeciesDto();
            DateCollected = new DateTime();
            Site = new SiteDto();
        }
    }
}
