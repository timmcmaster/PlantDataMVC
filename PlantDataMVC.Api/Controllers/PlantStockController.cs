using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Service;
using PlantDataMVC.Api.Helpers;
using PlantDataMVC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PlantDataMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class PlantStockController : ControllerBase
    {
        private readonly IPlantStockService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<PlantStockController> _logger;
        public PlantStockController(IUnitOfWorkAsync unitOfWorkAsync, IPlantStockService service, IMapper mapper, ILogger<PlantStockController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/PlantStock
        [HttpGet(Name = "PlantStockList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            int? speciesId = null,
            int? productTypeId = null)
        {
            try
            {
                // TODO: Current state doesn't return children by default, can only get with "fields" option
                // need to determine expected behaviour

                var childDataModelsToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    childDataModelsToInclude = DataShaping.GetIncludedObjectNames<PlantStockDataModel>(lstOfFields);
                }


                var context = _service.Queryable(useTracking: true);

                // TODO: Need to identify if sort field from DTO is in entity or not
                //       to determine if we can sort on projection or need to sort after list is materialised

                var dataModels = _mapper
                           .ProjectTo<PlantStockDataModel>(context, childDataModelsToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => speciesId == null || s.SpeciesId == speciesId)
                           .Where(s => productTypeId == null || s.ProductTypeId == productTypeId);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dataModels.Count(),
                    "PlantStockList",
                    new
                    {
                        sortParams.Sort,
                        speciesId,
                        productTypeId,
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
                               .Select(dataModel => DataShaping.CreateDataShapedObject(dataModel, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/PlantStock/5
        [HttpGet("{id:int}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetById(int id, [FromQuery] DataShapingParameters dsParams)
        {
            try
            {
                var includeJournalEntries = false;
                //var childDataModelsToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();

                    var childDataModelsToInclude =
                        DataShaping.GetIncludedObjectNames<PlantStockDataModel>(lstOfFields); // needed if using projectTo

                    includeJournalEntries = childDataModelsToInclude.Contains("JournalEntries");
                }

                PlantStockEntityModel item;

                if (includeJournalEntries)
                {
                    try
                    {
                        item = _service
                            .Queryable(useTracking: true)
                            .Include(p => p.Species).ThenInclude(m => m.Genus)
                            .Include(p => p.ProductType)
                            .Where(s => s.Id == id)
                            //.Select()
                            .Single();
                    }
                    catch (InvalidOperationException) // thrown by single if more than one element, no elements, or empty list
                    {
                        // treat as a not found result
                        item = null;
                    }
                }
                else
                {
                    item = _service.GetItemById(id);
                }

                if (item == null)
                {
                    return NotFound();
                }

                var itemDataModel = _mapper.Map<PlantStockEntityModel, PlantStockDataModel>(item);

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

        // POST: api/PlantStock
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdatePlantStockDataModel dataModelIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dataModelIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<CreateUpdatePlantStockDataModel, PlantStockEntityModel>(dataModelIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<PlantStockEntityModel, PlantStockDataModel>(entity);

                    return CreatedAtAction(nameof(GetById), new { id = dataModelOut.Id }, dataModelOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/PlantStock/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdatePlantStockDataModel dataModelIn)
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
                var entityFound = _service.Queryable(useTracking: false).FirstOrDefault(g => g.Id == id);

                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = _mapper.Map<CreateUpdatePlantStockDataModel, PlantStockEntityModel>(dataModelIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<PlantStockEntityModel, PlantStockDataModel>(entity);

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

        // PATCH: api/PlantStock/5
        // Partial update
        [HttpPatch("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdatePlantStockDataModel> itemPatchDoc)
        {
            try
            {
                if (itemPatchDoc == null)
                {
                    return BadRequest();
                }

                // Get domain entity
                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service.Queryable(useTracking: false).FirstOrDefault(g => g.Id == id);

                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dataModel
                var dataModelFound = _mapper.Map<PlantStockEntityModel, CreateUpdatePlantStockDataModel>(entityFound);

                // Apply changes to dataModel
                itemPatchDoc.ApplyTo(dataModelFound);

                var updatedEntity = _mapper.Map<CreateUpdatePlantStockDataModel, PlantStockEntityModel>(dataModelFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<PlantStockEntityModel, PlantStockDataModel>(updatedEntity);

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

        // DELETE: api/PlantStock/5
        [HttpDelete("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Delete(int id)
        {
            try
            {
                // Get domain entity
                var entityFound = _service.GetItemById(id);

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
