﻿using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.SeedBatch;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.SeedBatch;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedBatch
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

        public async Task<SeedBatchDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedBatch/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SeedBatchDto>(content);

                var model = _mapper.Map<SeedBatchDto, SeedBatchDeleteViewModel>(dto);
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