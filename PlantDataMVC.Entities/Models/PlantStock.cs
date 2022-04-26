using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class PlantStock: IEntity
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

        // Reverse navigation

        /// <summary>
        /// Child JournalEntries where [JournalEntry].[PlantStockId] point to this entity (FK_Transactions_PlantStock)
        /// </summary>
        public virtual ICollection<JournalEntry> JournalEntries { get; set; } // JournalEntry.FK_Transactions_PlantStock

        // Foreign keys

        /// <summary>
        /// Parent ProductType pointed by [PlantStock].([ProductTypeId]) (FK_PlantStock_ProductType)
        /// </summary>
        public virtual ProductType ProductType { get; set; } // FK_PlantStock_ProductType

        /// <summary>
        /// Parent Species pointed by [PlantStock].([SpeciesId]) (FK_PlantStock_Species)
        /// </summary>
        public virtual Species Species { get; set; } // FK_PlantStock_Species

        public PlantStock()
        {
            JournalEntries = new List<JournalEntry>();
        }
    }

}
