using Framework.Web.Core.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.Transaction;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Transaction
{
    public class TransactionDestroyEditModelFormHandler : IFormHandler<TransactionDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public TransactionDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(TransactionDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/JournalEntries/" + form.Id;
                var httpResponse = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}