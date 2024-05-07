using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IBarcodeLabelReportBuilder
    {
        string? GetBarcodeLabelReport(string layoutName, List<ProductPriceBarcodeItemRequestModel> requestedItems);
    }
}
