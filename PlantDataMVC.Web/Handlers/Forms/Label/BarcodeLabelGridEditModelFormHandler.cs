using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.ServiceModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Label;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class BarcodeLabelGridEditModelFormHandler : IFormHandler<BarcodeLabelGridEditModel, string>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public BarcodeLabelGridEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<string> Handle(BarcodeLabelGridEditModel form, CancellationToken cancellationToken)
        {
            string reportData = string.Empty;

            try
            {
                FetchBarcodeLabelReportAsyncRequestDTO requestDTO = new();

                var labelRequests = form.Items.Select(x => new ProductPriceBarcodeItemRequestModel() { ProductPriceId = x.ProductPriceId, LabelQuantity = x.LabelQuantity }).ToList();
                requestDTO.LabelRequests = labelRequests;

                var uri = "api/Label/FetchBarcodeLabelReportAsync";
                var response = await _plantDataApiClient.PostAsync<FetchBarcodeLabelReportAsyncRequestDTO, FetchBarcodeLabelReportAsyncResponseDTO>(uri, requestDTO, cancellationToken).ConfigureAwait(false);

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