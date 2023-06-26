using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IBarcodeLabelReportBuilder
    {
        string? GetBarcodeLabelReport(List<ProductPriceBarcodeItemRequestModel> requestedItems);
    }
}
