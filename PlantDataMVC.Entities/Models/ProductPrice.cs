// ReSharper disable CheckNamespace

using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class ProductPrice : IEntity
    {
        //// HACK: Putting Id in just to meet interface requirements
        //public override int Id
        //{
        //    get => -1;
        //    set { }
        //}

        [Required]
        [Display(Name = "Price list type ID")]
        public int PriceListTypeId { get; set; } // PriceListTypeId (Primary key)

        [Required]
        [Display(Name = "Product type ID")]
        public int ProductTypeId { get; set; } // ProductTypeId (Primary key)

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; } // Price

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date effective")]
        public System.DateTime DateEffective { get; set; } // DateEffective (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent PriceListType pointed by [ProductPrice].([PriceListTypeId]) (FK_ProductPrices_PriceListType)
        /// </summary>
        public virtual PriceListType PriceListType { get; set; } // FK_ProductPrices_PriceListType

        /// <summary>
        /// Parent ProductType pointed by [ProductPrice].([ProductTypeId]) (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual ProductType ProductType { get; set; } // FK_ProductPrices_ProductType

        public ProductPrice()
        {
        }
    }

}
// </auto-generated>
