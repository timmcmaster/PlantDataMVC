using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public class GenusEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Latin name")]
        public string LatinName { get; set; } // LatinName (length: 30)

        // Reverse navigation

        /// <summary>
        /// Child Species where [Species].[GenusId] point to this entity (FK_Species_Genus)
        /// </summary>
        public virtual ICollection<SpeciesEntityModel> Species { get; set; } // Species.FK_Species_Genus

        public GenusEntityModel()
        {
            Species = new List<SpeciesEntityModel>();
        }
    }

}

