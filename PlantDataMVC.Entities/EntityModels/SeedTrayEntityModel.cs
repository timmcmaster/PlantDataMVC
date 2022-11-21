using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class SeedTrayEntityModel : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Seed batch ID")]
        public int SeedBatchId { get; set; } // SeedBatchId

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date planted")]
        public System.DateTime DatePlanted { get; set; } // DatePlanted

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Treatment")]
        public string Treatment { get; set; } // Treatment (length: 50)

        [Required]
        [Display(Name = "Thrown out")]
        public bool ThrownOut { get; set; } // ThrownOut

        // Reverse navigation

        /// <summary>
        /// Child JournalEntries where [JournalEntry].[SeedTrayId] point to this entity (FK_Transactions_SeedTray)
        /// </summary>
        public virtual ICollection<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry.FK_Transactions_SeedTray

        // Foreign keys

        /// <summary>
        /// Parent SeedBatch pointed by [SeedTray].([SeedBatchId]) (FK_SeedTray_SeedBatch)
        /// </summary>
        public virtual SeedBatchEntityModel SeedBatch { get; set; } // FK_SeedTray_SeedBatch

        public SeedTrayEntityModel()
        {
            JournalEntries = new List<JournalEntryEntityModel>();
        }
    }

}
// </auto-generated>
