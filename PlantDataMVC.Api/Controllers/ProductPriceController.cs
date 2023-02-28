using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Service;
using PlantDataMVC.Api.Helpers;
using PlantDataMVC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using PlantDataMVC.Entities.EntityModels;
using System.Globalization;

namespace PlantDataMVC.Api.Controllers
{
    // TODO: add write methods with admin authorization

    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductPriceController> _logger;

        public ProductPriceController(IUnitOfWorkAsync unitOfWorkAsync, IProductPriceService service, IMapper mapper, ILogger<ProductPriceController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/ProductPrice
        [HttpGet(Name = "ProductPriceList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            [FromQuery] int? productTypeId = null,
            [FromQuery] int? priceListId = null,
            [FromQuery] string? strQueryDate = null
            )
        {
            try
            {
                DateTime? queryDate = (strQueryDate == null) ? null : DateTime.ParseExact(strQueryDate, "yyyyMMdd", CultureInfo.InvariantCulture);

                // TODO: Current state doesn't return children by default, can only get with "fields" option
                // need to determine expected behaviour

                var childDataModelsToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    childDataModelsToInclude = DataShaping.GetIncludedObjectNames<ProductPriceDataModel>(lstOfFields);
                }

                var context = _service.Queryable(useTracking: false);

                // TODO: Need to identify if sort field from DTO is in entity or not
                //       to determine if we can sort on projection or need to sort after list is materialised

                var dataModels = _mapper
                           .ProjectTo<ProductPriceDataModel>(context, childDataModelsToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => productTypeId == null || s.ProductTypeId == productTypeId)
                           .Where(s => priceListId == null || s.PriceListTypeId == priceListId)
                           .Where(s => queryDate == null || s.DateEffective >= queryDate)
;

                // HACK: use URL content to determine route used to get here
                // better solution is to add name to data tokens, as per following links
                // https://stackoverflow.com/questions/363211/how-can-i-get-the-route-name-in-controller-in-asp-net-mvc
                // https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dataModels.Count(),
                    "ProductPriceList",
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

                var itemList = dataModels
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
        // GET: api/ProductPrice/
        [HttpGet]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetByKeyFields([FromQuery] int productTypeId,
                                            [FromQuery] int priceListId,
                                            [FromQuery] string strEffectiveDate,
                                            [FromQuery] DataShapingParameters dsParams)
        {
            try
            {
                DateTime effectiveDate = DateTime.ParseExact(strEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);

                //var childDataModelsToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    //childDataModelsToInclude = DataShaping.GetIncludedObjectNames<ProductPriceDataModel>(lstOfFields);
                }

                var item = _service.GetItemByProductPriceListDate(productTypeId, priceListId, effectiveDate);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDataModel = _mapper.Map<ProductPriceEntityModel, ProductPriceDataModel>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDataModel, lstOfFields));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/ProductPrice
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] ProductPriceDataModel dataModelIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dataModelIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<ProductPriceDataModel, ProductPriceEntityModel>(dataModelIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<ProductPriceEntityModel, ProductPriceDataModel>(entity);

                    return CreatedAtAction(nameof(GetByKeyFields), 
                                           new { 
                                               productTypeId = dataModelOut.ProductTypeId,
                                               priceListId = dataModelOut.PriceListTypeId,
                                               strEffectiveDate = dataModelOut.DateEffective.ToString("yyyyMMdd")
                                           }, 
                                           dataModelOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/ProductPrice/
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put([FromBody] ProductPriceDataModel dataModelIn)
        {
            try
            {
                // Handle mapping failure - where dataModel is not in right format
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (dataModelIn == null)
                {
                    return BadRequest();
                }

                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service
                    .Queryable(useTracking: false)
                    .FirstOrDefault(g => g.ProductTypeId == dataModelIn.ProductTypeId && g.PriceListTypeId == dataModelIn.PriceListTypeId && g.DateEffective == dataModelIn.DateEffective);

                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = _mapper.Map<ProductPriceDataModel, ProductPriceEntityModel>(dataModelIn);
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<ProductPriceEntityModel, ProductPriceDataModel>(entity);

                    return Ok(dataModelOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH: api/ProductPrice/5
        // Partial update
        [HttpPatch]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch([FromQuery] int productTypeId,
                                   [FromQuery] int priceListId,
                                   [FromQuery] string strEffectiveDate, 
                                   [FromBody] JsonPatchDocument<ProductPriceDataModel> itemPatchDoc)
{
            try
            {
                DateTime effectiveDate = DateTime.ParseExact(strEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);

                if (itemPatchDoc == null)
                {
                    return BadRequest();
                }

                // Get domain entity
                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service.Queryable(useTracking: false)
                    .FirstOrDefault(g => g.ProductTypeId == productTypeId && g.PriceListTypeId == priceListId && g.DateEffective == effectiveDate);

                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dataModel
                var dataModelFound = _mapper.Map<ProductPriceEntityModel, ProductPriceDataModel>(entityFound);

                // Apply changes to dataModel
                itemPatchDoc.ApplyTo(dataModelFound);

                var updatedEntity = _mapper.Map<ProductPriceDataModel, ProductPriceEntityModel>(dataModelFound);
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<ProductPriceEntityModel, ProductPriceDataModel>(updatedEntity);

                    return Ok(dataModelOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/ProductPrice/5
        [HttpDelete]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Delete([FromQuery] int productTypeId,
                                    [FromQuery] int priceListId,
                                    [FromQuery] string strEffectiveDate)
        {
            try
            {
                DateTime effectiveDate = DateTime.ParseExact(strEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);

                // Get domain entity
                var entityFound = _service.GetItemByProductPriceListDate(productTypeId, priceListId, effectiveDate);

                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                _service.Delete(entityFound);
                _unitOfWorkAsync.SaveChanges();

                // return 204 (also via void return type)
                return new StatusCodeResult(StatusCodes.Status204NoContent);


                //return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
