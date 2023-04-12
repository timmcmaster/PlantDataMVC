using AutoMapper;
using Azure;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Common.Client.Models;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Label;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Label
{
    public class PlantLabelQueryHandler : IQueryHandler<PlantLabelQuery, ListViewModelStatic<PlantLabelListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PlantLabelQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<PlantLabelListViewModel>> Handle(PlantLabelQuery query, CancellationToken cancellationToken)
        {
            var modelList = new List<PlantLabelListViewModel>();

            var model = new ListViewModelStatic<PlantLabelListViewModel>(modelList,1,0,0, query.SortBy, query.SortAscending);

            return model;
        }
    }
}