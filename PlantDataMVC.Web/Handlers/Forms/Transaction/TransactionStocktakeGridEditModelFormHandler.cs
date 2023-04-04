using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.Transaction;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.Transaction
{
    public class TransactionStocktakeGridEditModelFormHandler : IFormHandler<TransactionStocktakeGridEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public TransactionStocktakeGridEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TransactionStocktakeGridEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var stocktakeDateTime = DateTime.Now;
                bool success = true;

                foreach (var item in form.Items)
                {
                    var diff = item.CountedQuantity - item.QuantityInStock;
                    if (diff != 0)
                    {
                        var newJournalEntry = new CreateUpdateJournalEntryDataModel()
                        {
                            SpeciesId = item.SpeciesId,
                            ProductTypeId = item.ProductTypeId,
                            TransactionDate = stocktakeDateTime,
                            JournalEntryTypeId = 9, // HACK: use hardcoded value for now (Stock adjustment)
                            Quantity = diff,
                            Source = $"Stocktake {stocktakeDateTime}",
                            Notes = item.Reason,
                            SeedTrayId = null
                        };

                        var uri = "api/JournalEntries";
                        var response = await _plantDataApiClient.PostAsync<CreateUpdateJournalEntryDataModel>(uri, newJournalEntry, cancellationToken).ConfigureAwait(false);
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            throw new UnauthorizedAccessException();
                        }
                        else
                        {
                            success = success && response.Success;
                        }
                    }
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