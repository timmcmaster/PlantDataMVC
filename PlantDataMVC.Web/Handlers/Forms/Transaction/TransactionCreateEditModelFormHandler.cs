﻿using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Transaction;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class TransactionCreateEditModelFormHandler : IFormHandler<TransactionCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public TransactionCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TransactionCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                JournalEntryDataModel item = _mapper.Map<TransactionCreateEditModel, JournalEntryDataModel>(form);

                var uri = "api/JournalEntries";
                var response = await _plantDataApiClient.PostAsync<JournalEntryDataModel>(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}