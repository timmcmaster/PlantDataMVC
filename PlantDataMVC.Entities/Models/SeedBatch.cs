using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class SeedBatch : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Species ID")]
        public int SpeciesId { get; set; } // SpeciesId

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date collected")]
        public System.DateTime DateCollected { get; set; } // DateCollected

        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Location")]
        public string Location { get; set; } // Location (length: 30)

        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Notes")]
        public string Notes { get; set; } // Notes (length: 200)

        [Display(Name = "Site ID")]
        public int? SiteId { get; set; } // SiteId

        // Reverse navigation

        /// <summary>
        /// Child SeedTrays where [SeedTray].[SeedBatchId] point to this entity (FK_SeedTray_SeedBatch)
        /// </summary>
        public virtual ICollection<SeedTray> SeedTrays { get; set; } // SeedTray.FK_SeedTray_SeedBatch

        // Foreign keys

        /// <summary>
        /// Parent Site pointed by [SeedBatch].([SiteId]) (FK_SeedBatch_Site)
        /// </summary>
        public virtual Site Site { get; set; } // FK_SeedBatch_Site

        /// <summary>
        /// Parent Species pointed by [SeedBatch].([SpeciesId]) (FK_SeedBatch_Species)
        /// </summary>
        public virtual Species Species { get; set; } // FK_SeedBatch_Species

        public SeedBatch()
        {
            SeedTrays = new List<SeedTray>();
        }
    }
}
