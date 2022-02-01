using Interfaces.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.Models
{
    public class Site : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Site name")]
        public string SiteName { get; set; } // SiteName (length: 50)

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Suburb")]
        public string Suburb { get; set; } // Suburb (length: 50)

        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; } // Latitude

        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; } // Longitude

        // Reverse navigation

        /// <summary>
        /// Child SeedBatches where [SeedBatch].[SiteId] point to this entity (FK_SeedBatch_Site)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SeedBatch> SeedBatches { get; set; } // SeedBatch.FK_SeedBatch_Site

        public Site()
        {
            SeedBatches = new System.Collections.Generic.List<SeedBatch>();
        }
    }

}
