using PlantDataMVC.Api.Models;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class GenusDataModel : IDto
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public ICollection<SpeciesDataModel> Species { get; set; }
    }
}