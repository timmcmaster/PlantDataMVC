using PlantData.Web.Mvc.Controllers.Queries;
using PlantData.Web.Mvc.Handlers.Views;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.Label
{
    public class BarcodeLabelLayoutDataModelListQueryHandler : ListQueryHandler<BarcodeLabelLayoutDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public BarcodeLabelLayoutDataModelListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<BarcodeLabelLayoutDataModel>> Handle(ListQuery<BarcodeLabelLayoutDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/Label/BarcodeLayouts";
            IEnumerable<BarcodeLabelLayoutDataModel> fullDataModelList = Enumerable.Empty<BarcodeLabelLayoutDataModel>();

            var response = await _plantDataApiClient.GetAsync<IEnumerable<BarcodeLabelLayoutDataModel>>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var dataModelList = response.Content;

                // Concatenate page to full list
                fullDataModelList = (fullDataModelList ?? Enumerable.Empty<BarcodeLabelLayoutDataModel>()).Concat(dataModelList ?? Enumerable.Empty<BarcodeLabelLayoutDataModel>());
            }
            else
            {
                success = false;
            }

            if (success)
            {
                return fullDataModelList;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}