﻿namespace PlantDataMVC.Api.Models.DataModels
{
    public class CreateUpdateSiteDataModel : IDataModel
    {
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}