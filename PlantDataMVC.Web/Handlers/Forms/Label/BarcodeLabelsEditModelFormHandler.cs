using Framework.Web.Forms;
using PlantDataMVC.Web.Models.EditModels.Label;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.ServiceModels;
using PlantDataMVC.Common.Client;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class BarcodeLabelsEditModelFormHandler : IFormHandler<BarcodeLabelsEditModel, string>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public BarcodeLabelsEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<string> Handle(BarcodeLabelsEditModel form, CancellationToken cancellationToken)
        {
            string reportData = string.Empty;

            try
            {
                FetchBarcodeLabelReportRequestDto requestDTO = new();

                requestDTO.LayoutName = form.LayoutName;
                
                var labelRequests = form.Items.Select(x => new ProductPriceBarcodeItemRequestModel() { ProductPriceId = x.ProductPriceId, LabelQuantity = x.LabelQuantity }).ToList();
                requestDTO.LabelRequests = labelRequests;

                var uri = "api/Label/FetchBarcodeLabelReport";
                var response = await _plantDataApiClient.PostAsync<FetchBarcodeLabelReportRequestDto, FetchBarcodeLabelReportResponseDto>(uri, requestDTO, cancellationToken).ConfigureAwait(false);

                if (response.Success)
                {
                    reportData = response.Content?.ReportDocument ?? string.Empty;
                }

                return reportData;
            }
            catch
            {
                return reportData;
            }
        }
    }
}