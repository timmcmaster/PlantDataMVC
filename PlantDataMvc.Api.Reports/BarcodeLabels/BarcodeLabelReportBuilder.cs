using Microsoft.Extensions.Logging;
using PlantDataMvc.Api.Reports.BarcodeLabels.Models;
using PlantDataMVC.Api.Models.DomainFunctions;
using PlantDataMVC.Api.Reports.InfoLabels;
using PlantDataMVC.Service;

namespace PlantDataMvc.Api.Reports.BarcodeLabels
{
    public class BarcodeLabelReportBuilder : IBarcodeLabelReportBuilder
    {
        private readonly ISpeciesService _service;
        private readonly ILogger<InfoLabelReportBuilder> _logger;

        public BarcodeLabelReportBuilder(ISpeciesService service, ILogger<InfoLabelReportBuilder> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<string?> GetBarcodeLabelReportAsync()
        {
            try
            {
                var reportModel = new BarcodeLabelReportModel();

                await LoadLabelItems(reportModel);

                return new BarcodeLabelReportRenderer(reportModel).BuildReport();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred");
                return null;
            }
        }

        private async Task LoadLabelItems(BarcodeLabelReportModel reportModel)
        {
            // Should get this from DB
            string labelText = "Tim McMaster";
            decimal price = 2.50M;
            string barcodeSKUText = "38 2.5";

            var labelItem = new BarcodeLabelItemModel()
            {
                LabelText =labelText,
                Price = $"{price.ToString("C")}",
                BarcodeText = barcodeSKUText
            };

            reportModel.LabelItems.Add(labelItem);
        }
    }
}
