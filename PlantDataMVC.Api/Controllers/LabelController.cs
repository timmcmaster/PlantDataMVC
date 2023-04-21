using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMvc.Api.Reports.BarcodeLabels;
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
        private readonly ISpeciesService _speciesService;
        private readonly IProductPriceService _priceService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<SpeciesController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public LabelController(IUnitOfWorkAsync unitOfWorkAsync, ISpeciesService speciesService, IProductPriceService priceService, IMapper mapper, ILogger<SpeciesController> logger, ILoggerFactory loggerFactory)
        {
            _speciesService = speciesService;
            _priceService = priceService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
            _loggerFactory = loggerFactory;
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
                ILogger<InfoLabelReportBuilder> logger = _loggerFactory.CreateLogger<InfoLabelReportBuilder>();
                var reportBuilder = new InfoLabelReportBuilder(_speciesService, logger);
                result.ReportDocument = await reportBuilder.GetInfoLabelReportAsync(dto.LabelRequests).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }

        // POST: api/Label/FetchBarcodeLabelReportAsync
        [HttpPost]
        [Route("FetchBarcodeLabelReportAsync")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<IActionResult> FetchBarcodeLabelReportAsync([FromBody] FetchBarcodeLabelReportAsyncRequestDTO? dto)
        {
            FetchBarcodeLabelReportAsyncResponseDTO result = new() { Success = true };
            if (dto == null)
            {
                result.Success = false;
                result.Message = $"Invalid request at {nameof(FetchBarcodeLabelReportAsync)}";
                return Ok(result);
            }

            try
            {
                ILogger<BarcodeLabelReportBuilder> logger = _loggerFactory.CreateLogger<BarcodeLabelReportBuilder>();
                var reportBuilder = new BarcodeLabelReportBuilder(_priceService, logger);
                result.ReportDocument = await reportBuilder.GetBarcodeLabelReportAsync(dto.LabelRequests).ConfigureAwait(false);
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
