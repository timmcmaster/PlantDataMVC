using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.BarcodeLabels;

public interface IBarcodeLabelReportBuilder
{
    string? GetBarcodeLabelReport(string layoutName, List<ProductPriceBarcodeItemRequestModel> requestedItems);
}
