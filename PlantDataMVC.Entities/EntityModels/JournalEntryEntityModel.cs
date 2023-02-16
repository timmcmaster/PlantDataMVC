// ReSharper disable CheckNamespace

using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{

    // JournalEntry
    public class JournalEntryEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Species ID")]
        public int SpeciesId { get; set; } // SpeciesId

        [Required]
        [Display(Name = "Product Type ID")]
        public int ProductTypeId { get; set; } // ProductTypeId

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } // Quantity

        [Required]
        [Display(Name = "Journal entry type ID")]
        public int JournalEntryTypeId { get; set; } // JournalEntryTypeId

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Transaction date")]
        public System.DateTime TransactionDate { get; set; } // TransactionDate

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Source")]
        public string Source { get; set; } // Source (length: 50)

        [Display(Name = "Seed tray ID")]
        public int? SeedTrayId { get; set; } // SeedTrayId

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Notes")]
        public string Notes { get; set; } // Notes (length: 50)

        // Foreign keys

        /// <summary>
        /// Parent JournalEntryType pointed by [JournalEntry].([JournalEntryTypeId]) (FK_Transactions_TransactionType)
        /// </summary>
        public virtual JournalEntryTypeEntityModel JournalEntryType { get; set; } // FK_Transactions_TransactionType

        /// <summary>
        /// Parent ProductType pointed by [JournalEntry].([SpeciesId]) (FK_Transactions_Species)
        /// </summary>
        public virtual SpeciesEntityModel Species { get; set; } // FK_Transactions_Species

        /// <summary>
        /// Parent ProductType pointed by [JournalEntry].([ProductTypeId]) (FK_Transactions_ProductType)
        /// </summary>
        public virtual ProductTypeEntityModel ProductType { get; set; } // FK_Transactions_ProductType

        /// <summary>
        /// Parent SeedTray pointed by [JournalEntry].([SeedTrayId]) (FK_Transactions_SeedTray)
        /// </summary>
        public virtual SeedTrayEntityModel SeedTray { get; set; } // FK_Transactions_SeedTray

        public JournalEntryEntityModel()
        {
        }
    }

}
