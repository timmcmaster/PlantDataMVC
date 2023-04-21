using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IBarcodeLabelReportBuilder
    {
        Task<string?> GetBarcodeLabelReportAsync();
    }
}
