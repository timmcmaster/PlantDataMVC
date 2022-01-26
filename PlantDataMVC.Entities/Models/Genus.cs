// ReSharper disable CheckNamespace

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interfaces.Domain.Entity;

namespace PlantDataMVC.Entities.Models
{
    public class Genus : Entity
    {
        [Required]
        [Display(Name = "Id")]
        public override int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Latin name")]
        public string LatinName { get; set; } // LatinName (length: 30)

        // Reverse navigation

        /// <summary>
        /// Child Species where [Species].[GenusId] point to this entity (FK_Species_Genus)
        /// </summary>
        public virtual ICollection<Species> Species { get; set; } // Species.FK_Species_Genus

        public Genus()
        {
            Species = new List<Species>();
        }
    }

}

