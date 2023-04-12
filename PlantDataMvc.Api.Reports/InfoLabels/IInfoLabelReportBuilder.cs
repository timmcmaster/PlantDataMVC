using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public interface IInfoLabelReportBuilder
    {
        Task<string?> GetInfoLabelReportAsync(List<SpeciesLabelItemRequestModel> requestedItems);
    }
}
