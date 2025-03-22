using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.Site;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Site
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public SiteUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SiteUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateSiteDataModel item = _mapper.Map<SiteUpdateEditModel, CreateUpdateSiteDataModel>(form);

                // Update with PUT
                var uri = "api/Site/" + form.Id;
                var response = await _plantDataApiClient.PutAsync(uri, item, cancellationToken).ConfigureAwait(false);
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