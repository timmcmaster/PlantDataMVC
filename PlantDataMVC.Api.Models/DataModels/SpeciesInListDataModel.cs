using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SpeciesInListDataModel : IDataModel
    {
        public int Id { get; set; }
        public int GenusId { get; set; }
        public string Binomial { get; }
        public string SpecificName { get; set; }
        public string CommonName { get; set; }
    }
}