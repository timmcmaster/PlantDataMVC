using AutoMapper;
using Framework.Web.Views;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.SaleEvent;
using PlantDataMVC.Web.Models.ViewModels.SaleEvent;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.SaleEvent
{
    public class EditQueryHandler : IQueryHandler<EditQuery, SaleEventEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<SaleEventEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SaleEvent/" + query.Id;
            var response = await _plantDataApiClient.GetAsync<SaleEventDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<SaleEventDataModel, SaleEventEditViewModel>(response.Content);
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