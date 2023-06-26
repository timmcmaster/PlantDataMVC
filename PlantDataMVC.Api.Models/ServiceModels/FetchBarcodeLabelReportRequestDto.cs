using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchBarcodeLabelReportRequestDto
    {
        public List<ProductPriceBarcodeItemRequestModel> LabelRequests { get; set; } = new();
    }
}
