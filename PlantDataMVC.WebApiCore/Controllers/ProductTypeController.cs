using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Service;
using PlantDataMVC.WebApiCore.Helpers;
using PlantDataMVC.WebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Controllers
{
    // TODO: add write methods with admin authorization

    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductTypeController> _logger;

        public ProductTypeController(IUnitOfWorkAsync unitOfWorkAsync, IProductTypeService service, IMapper mapper, ILogger<ProductTypeController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/ProductType
        [HttpGet(Name = "ProductTypeList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams)
        {
            try
            {
                // TODO: Current state doesn't return children by default, can only get with "fields" option
                // need to determine expected behaviour

                var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<ProductTypeDto>(lstOfFields);
                }

                var context = _service.Queryable();

                var dtos = _mapper
                           .ProjectTo<ProductTypeDto>(context, childDtosToInclude.ToArray())
                           .ApplySort(sortParams.Sort);

                // HACK: use URL content to determine route used to get here
                // better solution is to add name to data tokens, as per following links
                // https://stackoverflow.com/questions/363211/how-can-i-get-the-route-name-in-controller-in-asp-net-mvc
                // https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Count(),
                    "ProductTypeList",
                    new
                    {
                        sortParams.Sort,
                        dsParams.Fields
                    },
                    pgParams.Page,
                    pgParams.PageSize);

                foreach (var hdr in paginationHeaders)
                {
                    HttpContext.Response.Headers.Add(hdr);
                }

                var itemList = dtos
                               .Paginate(pgParams.Page, pgParams.PageSize)
                               .ToList()
                               .Select(prodType => DataShaping.CreateDataShapedObject(prodType, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
