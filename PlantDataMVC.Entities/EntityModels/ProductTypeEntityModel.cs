using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class ProductTypeEntityModel : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child PlantStocks where [PlantStock].[ProductTypeId] point to this entity (FK_PlantStock_ProductType)
        /// </summary>
        public virtual ICollection<PlantStockEntityModel> PlantStocks { get; set; } // PlantStock.FK_PlantStock_ProductType
        /// <summary>
        /// Child ProductPrices where [ProductPrice].[ProductTypeId] point to this entity (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual ICollection<ProductPriceEntityModel> ProductPrices { get; set; } // ProductPrice.FK_ProductPrices_ProductType

        public ProductTypeEntityModel()
        {
            PlantStocks = new List<PlantStockEntityModel>();
            ProductPrices = new List<ProductPriceEntityModel>();
        }
    }

}
