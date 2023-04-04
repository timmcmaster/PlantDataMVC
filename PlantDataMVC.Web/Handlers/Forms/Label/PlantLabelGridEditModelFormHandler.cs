using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Label;
using System;
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
                var stocktakeDateTime = DateTime.Now;
                bool success = true;

                foreach (var item in form.Items)
                {
                    // Compile model list to send to report generator
                }
                return success;
            }
            catch
            {
                return false;
            }
        }
    }
}