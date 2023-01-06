using PlantDataMVC.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateGenusDataModel : IDataModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name is too long")]
        public string LatinName { get; set; }
    }
}