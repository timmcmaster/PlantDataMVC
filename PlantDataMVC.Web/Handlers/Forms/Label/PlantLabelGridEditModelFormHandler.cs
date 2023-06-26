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
    public class PlantLabelGridEditModelFormHandler : IFormHandler<PlantLabelGridEditModel, string>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantLabelGridEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<string> Handle(PlantLabelGridEditModel form, CancellationToken cancellationToken)
        {
            string reportData = string.Empty;

            try
            {
                FetchPlantInfoLabelReportRequestDto requestDTO = new();

                var labelRequests = form.Items.Select(x => new SpeciesLabelItemRequestModel() { SpeciesId = x.SpeciesId, LabelQuantity = x.LabelQuantity }).ToList();
                requestDTO.LabelRequests = labelRequests;

                var uri = "api/Label/FetchPlantInfoLabelReport";
                var response = await _plantDataApiClient.PostAsync<FetchPlantInfoLabelReportRequestDto,FetchPlantInfoLabelReportResponseDto>(uri, requestDTO, cancellationToken).ConfigureAwait(false);

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