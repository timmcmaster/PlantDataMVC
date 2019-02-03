﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Models.ViewModels
{
    public class TrayListViewModel : IViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Seed Batch Id")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public TrayListViewModel()
        {
            DatePlanted = new DateTime();
        }
    }
}
