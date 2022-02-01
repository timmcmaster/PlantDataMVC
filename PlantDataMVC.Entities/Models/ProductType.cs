﻿// ReSharper disable CheckNamespace

using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class ProductType : IEntity
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
        public virtual System.Collections.Generic.ICollection<PlantStock> PlantStocks { get; set; } // PlantStock.FK_PlantStock_ProductType
        /// <summary>
        /// Child ProductPrices where [ProductPrice].[ProductTypeId] point to this entity (FK_ProductPrices_ProductType)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductPrice> ProductPrices { get; set; } // ProductPrice.FK_ProductPrices_ProductType

        public ProductType()
        {
            PlantStocks = new System.Collections.Generic.List<PlantStock>();
            ProductPrices = new System.Collections.Generic.List<ProductPrice>();
        }
    }

}
