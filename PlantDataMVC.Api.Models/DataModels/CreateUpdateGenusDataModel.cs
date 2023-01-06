using PlantDataMVC.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateGenusDataModel : IDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string LatinName { get; set; }
    }
}