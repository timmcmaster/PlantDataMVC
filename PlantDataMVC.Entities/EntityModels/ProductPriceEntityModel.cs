using System;
using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class ProductPriceEntityModel : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Price list type ID")]
        public int PriceListTypeId { get; set; } // PriceListTypeId (Unique key 1)

        [Required]
        [Display(Name = "Product type ID")]
        public int ProductTypeId { get; set; } // ProductTypeId (Unique key 2)

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; } // Price

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date effective")]
        public DateTime DateEffective { get; set; } // DateEffective (Unique key 3)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(40)]
        [StringLength(40)]
        [Display(Name = "Barcode SKU")]
        public string BarcodeSKU { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent PriceListType pointed by [ProductPrice].([PriceListTypeId]) (FK_ProductPrices_PriceListType)
        /// </summary>
        public virtual PriceListTypeEntityModel PriceListType { get; set; } // FK_ProductPrices_PriceListType

        /// <summary>
        /// Parent ProductType pointed by [ProductPrice].([ProductTypeId]) (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual ProductTypeEntityModel ProductType { get; set; } // FK_ProductPrices_ProductType

        public ProductPriceEntityModel()
        {
        }
    }
}