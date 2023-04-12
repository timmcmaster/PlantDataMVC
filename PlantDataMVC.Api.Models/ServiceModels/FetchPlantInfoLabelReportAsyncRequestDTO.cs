using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchPlantInfoLabelReportAsyncRequestDTO
    {
        public List<SpeciesLabelItemRequestModel> LabelRequests { get; set; } = new();
    }
}
