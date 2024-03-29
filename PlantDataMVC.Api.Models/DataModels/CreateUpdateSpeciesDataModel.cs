﻿namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSpeciesDataModel : IDataModel
    {
        public int GenusId { get; set; }
        public string SpecificName { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int? PropagationTime { get; set; }
        public bool Native { get; set; }
    }
}