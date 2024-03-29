﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Web.Models.ViewModels.SeedTray
{
    public class SeedTrayNewViewModel
    {
        //[Display(Name = "Seed Batch")]
        //public SeedBatchDataModel SeedBatch { get; set; }

        [Display(Name = "Seed Batch")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Sown")]
        public DateTime DateSown { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }


        public SeedTrayNewViewModel()
        {
            //SeedBatch = new SeedBatchDataModel();
            DateSown = new DateTime();
        }
    }
}
