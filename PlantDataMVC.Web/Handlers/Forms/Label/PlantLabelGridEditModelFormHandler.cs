using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.ServiceModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Label;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class PlantLabelGridEditModelFormHandler : IFormHandler<PlantLabelGridEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantLabelGridEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PlantLabelGridEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                bool success = true;

                FetchPlantInfoLabelReportAsyncRequestDTO requestDTO = new();

                var labelRequests = form.Items.Select(x => new SpeciesLabelItemRequestModel() { SpeciesId = x.SpeciesId, LabelQuantity = x.LabelQuantity }).ToList();
                requestDTO.LabelRequests = labelRequests;

                var uri = "api/Label/FetchPlantInfoLabelReportAsync";
                var response = await _plantDataApiClient.PostAsync<FetchPlantInfoLabelReportAsyncRequestDTO,FetchPlantInfoLabelReportAsyncResponseDTO>(uri, requestDTO, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}