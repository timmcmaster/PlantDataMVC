using Interfaces.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class StocktakeHeaderEntityModel : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Stocktake Date")]
        public DateTime StocktakeDate { get; set; }

        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Reference")]
        public string Reference { get; set; }

        public virtual ICollection<StocktakeLineEntityModel> Lines { get; set; }

        public StocktakeHeaderEntityModel()
        {
            Lines = new List<StocktakeLineEntityModel>();
        }
    }
}