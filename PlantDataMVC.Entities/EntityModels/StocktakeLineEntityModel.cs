using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class StocktakeLineEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Header Id")]
        public int HeaderId { get; set; }

        [Required]
        [Display(Name = "Species Id")]
        public int SpeciesId { get; set; }

        [Required]
        [Display(Name = "Product Type Id")]
        public int ProductTypeId { get; set; }

        [Required]
        [Display(Name = "Expected Quantity")]
        public int ExpectedQuantity { get; set; }

        [Required]
        [Display(Name = "Counted Quantity")]
        public int CountedQuantity { get; set; }

        [Required]
        [Display(Name = "Applied")]
        public bool Applied { get; set; }

        public virtual ProductTypeEntityModel ProductType { get; set; } = null!;

        public virtual SpeciesEntityModel Species { get; set; } = null!;

        public virtual StocktakeHeaderEntityModel Header { get; set; }
    }
}