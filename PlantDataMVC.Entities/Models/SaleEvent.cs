using Interfaces.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class SaleEvent : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Sale name")]
        public string Name { get; set; } 

        [Display(Name = "Sale date")]
        public DateTime? SaleDate { get; set; }

        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
