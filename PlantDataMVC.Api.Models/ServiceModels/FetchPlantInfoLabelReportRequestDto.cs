using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchPlantInfoLabelReportRequestDto
    {
        public List<SpeciesLabelItemRequestModel> LabelRequests { get; set; } = new();
    }
}
