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

        public async Task<string?> GetBarcodeLabelReportAsync(List<ProductPriceBarcodeItemRequestModel> requestedItems)
        {
            try
            {
                var reportModel = new BarcodeLabelReportModel();

                await LoadLabelItems(reportModel,requestedItems);

                return new BarcodeLabelReportRenderer(reportModel).BuildReport();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred");
                return null;
            }
        }

        private async Task LoadLabelItems(BarcodeLabelReportModel reportModel, List<ProductPriceBarcodeItemRequestModel> requestedItems)
        {
            //foreach (var item in requestedItems)
            //{
            //    var productPriceEntity = _service.GetItemById(item.ProductPriceId);
            //    if (productPriceEntity != null)
            //    {
            //        var labelItem = new BarcodeLabelItemModel()
            //        {
            //            LabelText = "Tim McMaster",
            //            Price = $"{productPriceEntity.Price.ToString("C")}",
            //            BarcodeText = productPriceEntity.ProductSKU
            //        };
            //        reportModel.LabelItems.Add(labelItem);
            //    }
            //}

            // Should get this from DB
            string labelText = "Tim McMaster";
            decimal price = 2.50M;
            string barcodeSKUText = "38 2.5";

            var tempLabelItem = new BarcodeLabelItemModel()
            {
                LabelText =labelText,
                Price = $"{price.ToString("C")}",
                BarcodeText = barcodeSKUText
            };

            reportModel.LabelItems.Add(tempLabelItem);
        }
    }
}
