﻿using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.SeedTray;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedTray
{
    public class EditQueryHandler : IQueryHandler<EditQuery, SeedTrayEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SeedTrayEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedTray/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                var model = _mapper.Map<SeedTrayDto, SeedTrayEditViewModel>(dto);
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