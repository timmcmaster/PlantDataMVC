using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMvc3.UI.Models
{
    public class TrayEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

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
