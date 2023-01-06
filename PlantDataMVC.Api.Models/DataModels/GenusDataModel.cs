using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class GenusDataModel : IDataModel
    {
        public int Id { get; set; }
        public string LatinName { get; set; }
        public ICollection<SpeciesDataModel> Species { get; set; }
    }
}