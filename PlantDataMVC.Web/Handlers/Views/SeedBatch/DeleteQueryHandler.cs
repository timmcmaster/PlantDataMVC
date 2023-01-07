using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.SeedBatch;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels.Genus;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Web.Handlers.Views.SeedBatch
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, SeedBatchDeleteViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public DeleteQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SeedBatchDeleteViewModel> Handle(DeleteQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedBatch/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<SeedBatchDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SeedBatchDataModel, SeedBatchDeleteViewModel>(response.Content);
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