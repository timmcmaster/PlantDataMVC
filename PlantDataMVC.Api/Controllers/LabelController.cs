using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMVC.Api.Models.ServiceModels;
using PlantDataMVC.Api.Reports.InfoLabels;
using PlantDataMVC.Service;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class LabelController : ControllerBase
    {
        private readonly ISpeciesService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<SpeciesController> _logger;

        public LabelController(IUnitOfWorkAsync unitOfWorkAsync, ISpeciesService service, IMapper mapper, ILogger<SpeciesController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // POST: api/Label/FetchPlantInfoLabelReportAsync
        [HttpPost]
        [Route("FetchPlantInfoLabelReportAsync")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<IActionResult> FetchPlantInfoLabelReportAsync([FromBody] FetchPlantInfoLabelReportAsyncRequestDTO? dto)
        {
            FetchPlantInfoLabelReportAsyncResponseDTO result = new() { Success = true };
            if (dto == null)
            {
                result.Success = false;
                result.Message = $"Invalid request at {nameof(FetchPlantInfoLabelReportAsync)}";
                return Ok(result);
            }

            try
            {
                var reportBuilder = new InfoLabelReportBuilder(_service);
                result.ReportDocument = await reportBuilder.GetInfoLabelReportAsync(dto.LabelRequests).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}
