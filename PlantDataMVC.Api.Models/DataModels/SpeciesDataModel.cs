using System.Collections.Generic;
using DelegateDecompiler;

namespace PlantDataMVC.Api.Models.DataModels
{
    public class SpeciesDataModel : IDataModel
    {
        public int Id { get; set; }
        public int GenusId { get; set; }
        public string GenusName { get; set; }
        public string SpecificName { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int? PropagationTime { get; set; }
        public bool Native { get; set; }

        [Computed]
        public string SpeciesBinomial =>  $"{GenusName} {SpecificName}";
        public ICollection<PlantStockDataModel> PlantStocks { get; set; }
        public ICollection<SeedBatchDataModel> SeedBatches { get; set; }
    }
}