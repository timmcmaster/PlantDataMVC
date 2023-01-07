using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.Transaction;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Web.Handlers.Views.Transaction
{
    public class EditQueryHandler : IQueryHandler<EditQuery, TransactionEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<TransactionEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/JournalEntries/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<JournalEntryDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<JournalEntryDataModel, TransactionEditViewModel>(response.Content);
                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}