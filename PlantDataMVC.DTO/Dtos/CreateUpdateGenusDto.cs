using Interfaces.DTO;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdateGenusDto : IDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string LatinName { get; set; }
    }
}