// ReSharper disable CheckNamespace

using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{

    // JournalEntry
    public class JournalEntry: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Plant stock ID")]
        public int PlantStockId { get; set; } // PlantStockId

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
        public virtual JournalEntryType JournalEntryType { get; set; } // FK_Transactions_TransactionType

        /// <summary>
        /// Parent PlantStock pointed by [JournalEntry].([PlantStockId]) (FK_Transactions_PlantStock)
        /// </summary>
        public virtual PlantStock PlantStock { get; set; } // FK_Transactions_PlantStock

        /// <summary>
        /// Parent SeedTray pointed by [JournalEntry].([SeedTrayId]) (FK_Transactions_SeedTray)
        /// </summary>
        public virtual SeedTray SeedTray { get; set; } // FK_Transactions_SeedTray

        public JournalEntry()
        {
        }
    }

}
