// ReSharper disable CheckNamespace

using DelegateDecompiler;
using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantDataMVC.Entities.Models
{
    public class Species : IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Genus ID")]
        public int GenusId { get; set; } // GenusId

        [Required(AllowEmptyStrings = true)]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Specific name")]
        public string SpecificName { get; set; } // SpecificName (length: 30)

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Common name")]
        public string CommonName { get; set; } // CommonName (length: 50)

        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; } // Description (length: 200)

        [Display(Name = "Propagation time")]
        public int? PropagationTime { get; set; } // PropagationTime

        [Required]
        [Display(Name = "Native")]
        public bool Native { get; set; } // Native

        /// <summary>
        /// Gets the binomial string for this species.
        /// This property is not mapped. It is relevant only to views and not updates.
        /// </summary>
        /// <value>
        /// The binomial string.
        /// </value>
        [NotMapped]
        [Computed]
        public string Binomial
        {
            get
            {
                //var genericName = Genus.LatinName.Trim();
                //var specificName = SpecificName.Trim();

                //if (string.IsNullOrEmpty(genericName) && string.IsNullOrEmpty(specificName))
                //{
                //    return "";
                //}
                //else if (string.IsNullOrEmpty(genericName))
                //{
                //    return SpecificName;
                //}
                //else if (string.IsNullOrEmpty(SpecificName.Trim()))
                //{
                //    return genericName;
                //}
                //else
                //{
                //    return $"{genericName} {specificName}";
                //}
                return Genus.LatinName + " " + SpecificName;
            }
        }
        // Reverse navigation

        /// <summary>
        /// Child PlantStocks where [PlantStock].[SpeciesId] point to this entity (FK_PlantStock_Species)
        /// </summary>
        public virtual ICollection<PlantStock> PlantStocks { get; set; } // PlantStock.FK_PlantStock_Species
        /// <summary>
        /// Child SeedBatches where [SeedBatch].[SpeciesId] point to this entity (FK_SeedBatch_Species)
        /// </summary>
        public virtual ICollection<SeedBatch> SeedBatches { get; set; } // SeedBatch.FK_SeedBatch_Species

        // Foreign keys

        /// <summary>
        /// Parent Genus pointed by [Species].([GenusId]) (FK_Species_Genus)
        /// </summary>
        public virtual Genus Genus { get; set; } // FK_Species_Genus

        public Species()
        {
            PlantStocks = new List<PlantStock>();
            SeedBatches = new List<SeedBatch>();
        }

    }

}
