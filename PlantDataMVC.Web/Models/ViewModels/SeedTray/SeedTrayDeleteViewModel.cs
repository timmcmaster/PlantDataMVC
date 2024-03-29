﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Models.ViewModels.SeedTray
{
    public class SeedTrayDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Seed Batch Id")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Species Name")]
        public string SpeciesBinomial { get; private set; }

        [Display(Name = "Date Sown")]
        public DateTime DateSown { get; set; }

        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public SeedTrayDeleteViewModel()
        {
            DateSown = new DateTime();
        }
    }
}
