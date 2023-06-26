using Microsoft.Extensions.Logging;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.DomainFunctions;
using PlantDataMVC.Api.Reports.InfoLabels.Models;
using PlantDataMVC.Service;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public class InfoLabelReportBuilder : IInfoLabelReportBuilder
    {
        private readonly ISpeciesService _service;
        private readonly ILogger<InfoLabelReportBuilder> _logger;

        public InfoLabelReportBuilder(ISpeciesService service, ILogger<InfoLabelReportBuilder> logger)
        {
            _service = service;
            _logger = logger;
        }

        public string? GetInfoLabelReport(List<SpeciesLabelItemRequestModel> requestedItems)
        {
            try
            {
                var reportModel = new InfoLabelReportModel();

                LoadLabelItems(reportModel, requestedItems);

                return new InfoLabelReportRenderer(reportModel).BuildReport();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred");
                return null;
            }
        }

        private void LoadLabelItems(InfoLabelReportModel reportModel, List<SpeciesLabelItemRequestModel> requestedItems)
        {
            foreach (var item in requestedItems)
            {
                var speciesEntity = _service.GetItemById(item.SpeciesId);
                if (speciesEntity != null)
                {
                    var labelItem = new InfoLabelItemModel()
                    {
                        LabelQuantity = item.LabelQuantity,
                        SpeciesBinomial = SpeciesFunctions.GetBinomial(speciesEntity.Genus.LatinName, speciesEntity.SpecificName),
                        CommonName = speciesEntity.CommonName,
                        Description = speciesEntity.Description
                    };

                    reportModel.LabelItems.Add(labelItem);
                }
            }
        }
    }
}
