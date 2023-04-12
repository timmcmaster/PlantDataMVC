using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.DomainFunctions;
using PlantDataMVC.Api.Reports.InfoLabels.Models;
using PlantDataMVC.Service;

namespace PlantDataMVC.Api.Reports.InfoLabels
{
    public class InfoLabelReportBuilder : IInfoLabelReportBuilder
    {
        private readonly ISpeciesService _service;

        public InfoLabelReportBuilder(ISpeciesService service)
        {
            _service = service;
        }

        public async Task<string?> GetInfoLabelReportAsync(List<SpeciesLabelItemRequestModel> requestedItems)
        {
            try
            {
                var reportModel = new InfoLabelReportModel();

                await LoadLabelItems(reportModel, requestedItems);

                return new InfoLabelReportRenderer(reportModel).BuildReport();
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return null;
            }
}

        private async Task LoadLabelItems(InfoLabelReportModel reportModel, List<SpeciesLabelItemRequestModel> requestedItems)
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
