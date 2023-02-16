using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Transaction;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class TransactionUpdateEditModelFormHandler : IFormHandler<TransactionUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public TransactionUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TransactionUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateJournalEntryDataModel item = _mapper.Map<TransactionUpdateEditModel, CreateUpdateJournalEntryDataModel>(form);

                // Update with PUT
                var uri = "api/JournalEntries/" + form.Id;
                var response = await _plantDataApiClient.PutAsync<CreateUpdateJournalEntryDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}