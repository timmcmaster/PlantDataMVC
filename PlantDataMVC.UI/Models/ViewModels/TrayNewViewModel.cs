﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.Domain.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.UI.Models
{
    public class TrayNewViewModel
    {
        [Display(Name = "Seed Batch Id")]
        public int SeedBatchId { get; set; }

        [Display(Name = "Date Planted")]
        public DateTime DatePlanted { get; set; }

        [StringLength(50), DataType("CustomString")]
        public string Treatment { get; set; }

        [Display(Name = "Thrown Out")]
        public bool ThrownOut { get; set; }
    }
}