using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IInfoLabelReportBuilder
    {
        string? GetInfoLabelReport(List<SpeciesLabelItemRequestModel> requestedItems);
    }
}
