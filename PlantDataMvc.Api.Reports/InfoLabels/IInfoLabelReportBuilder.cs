using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IInfoLabelReportBuilder
    {
        Task<string?> GetInfoLabelReportAsync(List<SpeciesLabelItemRequestModel> requestedItems);
    }
}
