using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchBarcodeLabelReportAsyncRequestDTO
    {
        public List<ProductPriceBarcodeItemRequestModel> LabelRequests { get; set; } = new();
    }
}
