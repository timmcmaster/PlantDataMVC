using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class PriceListTypeEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name (length: 50)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1)]
        [StringLength(1)]
        [Display(Name = "Kind")]
        public string Kind { get; set; } // Kind (length: 1)

        // Reverse navigation

        /// <summary>
        /// Child ProductPrices where [ProductPrice].[PriceListTypeId] point to this entity (FK_ProductPrices_PriceListType)
        /// </summary>
        public virtual ICollection<ProductPriceEntityModel> ProductPrices { get; set; } // ProductPrice.FK_ProductPrices_PriceListType

        public PriceListTypeEntityModel()
        {
            ProductPrices = new List<ProductPriceEntityModel>();
        }

    }

}
