using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class PlantStockEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Species ID")]
        public int SpeciesId { get; set; } // SpeciesId

        [Required]
        [Display(Name = "Product type ID")]
        public int ProductTypeId { get; set; } // ProductTypeId

        [Required]
        [Display(Name = "Quantity in stock")]
        public int QuantityInStock { get; set; } // QuantityInStock

        // Foreign keys

        /// <summary>
        /// Parent ProductType pointed by [PlantStock].([ProductTypeId]) (FK_PlantStock_ProductType)
        /// </summary>
        public virtual ProductTypeEntityModel ProductType { get; set; } // FK_PlantStock_ProductType

        /// <summary>
        /// Parent Species pointed by [PlantStock].([SpeciesId]) (FK_PlantStock_Species)
        /// </summary>
        public virtual SpeciesEntityModel Species { get; set; } // FK_PlantStock_Species

        public PlantStockEntityModel()
        {
        }
    }

}
