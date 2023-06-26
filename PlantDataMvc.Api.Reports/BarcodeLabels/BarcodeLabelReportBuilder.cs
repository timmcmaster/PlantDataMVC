using Microsoft.Extensions.Logging;
using PlantDataMvc.Api.Reports.BarcodeLabels.Models;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Reports.InfoLabels;
using PlantDataMVC.Service;

namespace PlantDataMvc.Api.Reports.BarcodeLabels
{
    public class BarcodeLabelReportBuilder : IBarcodeLabelReportBuilder
    {
        private readonly ILogger<BarcodeLabelReportBuilder> _logger;
        private readonly IProductPriceService _service;

        public BarcodeLabelReportBuilder(IProductPriceService service, ILogger<BarcodeLabelReportBuilder> logger)
        {
            _logger = logger;
            _service = service;
        }

        public string? GetBarcodeLabelReport(List<ProductPriceBarcodeItemRequestModel> requestedItems)
        {
            try
            {
                var reportModel = new BarcodeLabelReportModel();

                LoadLabelItems(reportModel,requestedItems);

                return new BarcodeLabelReportRenderer(reportModel).BuildReport();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred");
                return null;
            }
        }

        private void LoadLabelItems(BarcodeLabelReportModel reportModel, List<ProductPriceBarcodeItemRequestModel> requestedItems)
        {
            foreach (var item in requestedItems)
            {
                var productPriceEntity = _service.GetItemById(item.ProductPriceId);
                if (productPriceEntity != null)
                {
                    var labelItem = new BarcodeLabelItemModel()
                    {
                        LabelText = "Tim McMaster",
                        Price = $"{productPriceEntity.Price.ToString("C")}",
                        BarcodeText = productPriceEntity.BarcodeSKU
                    };
                    reportModel.LabelItems.Add(labelItem);
                }
            }
        }
    }
}
