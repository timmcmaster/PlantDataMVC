﻿using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.UICore.Controllers.Queries.SeedBatch;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.SeedBatch;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedBatch
{
    public class EditQueryHandler : IQueryHandler<EditQuery, SeedBatchEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SeedBatchEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedBatch/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dataModel = JsonConvert.DeserializeObject<SeedBatchDataModel>(content);

                var model = _mapper.Map<SeedBatchDataModel, SeedBatchEditViewModel>(dataModel);
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