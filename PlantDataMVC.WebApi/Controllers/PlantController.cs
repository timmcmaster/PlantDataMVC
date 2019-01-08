﻿using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantController : BaseApiController<Plant>
    {
        public PlantController(IPlantDataService dataService) : base(dataService)
        {
        }
    }
}
