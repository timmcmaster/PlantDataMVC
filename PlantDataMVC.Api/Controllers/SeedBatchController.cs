using AutoMapper;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Service;
using PlantDataMVC.Api.Helpers;
using PlantDataMVC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class SeedBatchController : ControllerBase
    {
        private readonly ISeedBatchService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<SeedBatchController> _logger;

        public SeedBatchController(IUnitOfWorkAsync unitOfWorkAsync, ISeedBatchService service, IMapper mapper, ILogger<SeedBatchController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/SeedBatch
        [HttpGet(Name ="SeedBatchList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            int? speciesId = null)
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
                    childDataModelsToInclude = DataShaping.GetIncludedObjectNames<SpeciesDataModel>(lstOfFields);
                }

                var context = _service.Queryable(useTracking: true);

                // TODO: Need to identify if sort field from DTO is in entity or not
                //       to determine if we can sort on projection or need to sort after list is materialised

                //IList<SpeciesInListDataModel> itemList = context
                //    .ProjectTo<SpeciesInListDataModel>()
                //    .ApplySort(sort)
                //    .ToList();

                var dataModels = _mapper
                           .ProjectTo<SeedBatchDataModel>(context, childDataModelsToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => speciesId == null || s.SpeciesId == speciesId);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dataModels.Count(),
                    "SeedBatchList",
                    new
                    {
                        sortParams.Sort,
                        speciesId,
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
                               .Select(seedBatch => DataShaping.CreateDataShapedObject(seedBatch, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/SeedBatch/5
        [HttpGet("{id:int}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetById(int id, [FromQuery] DataShapingParameters dsParams)
        {
            try
            {
                //var childDataModelsToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    //childDataModelsToInclude = DataShaping.GetIncludedObjectNames<SpeciesDataModel>(lstOfFields);
                }

                var item = _service.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDataModel = _mapper.Map<SeedBatchEntityModel, SeedBatchDataModel>(item);

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

        // POST: api/SeedBatch
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdateSeedBatchDataModel dataModelIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dataModelIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<CreateUpdateSeedBatchDataModel, SeedBatchEntityModel>(dataModelIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<SeedBatchEntityModel, SeedBatchDataModel>(entity);

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

        // PUT: api/SeedBatch/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdateSeedBatchDataModel dataModelIn)
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

                var entity = _mapper.Map<CreateUpdateSeedBatchDataModel, SeedBatchEntityModel>(dataModelIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<SeedBatchEntityModel, SeedBatchDataModel>(entity);

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

        // PATCH: api/SeedBatch/5
        // Partial update
        [HttpPatch("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdateSeedBatchDataModel> itemPatchDoc)
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
                var dataModelFound = _mapper.Map<SeedBatchEntityModel, CreateUpdateSeedBatchDataModel>(entityFound);

                // Apply changes to dataModel
                itemPatchDoc.ApplyTo(dataModelFound);

                var updatedEntity = _mapper.Map<CreateUpdateSeedBatchDataModel, SeedBatchEntityModel>(dataModelFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dataModelOut = _mapper.Map<SeedBatchEntityModel, SeedBatchDataModel>(updatedEntity);

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

        // DELETE: api/SeedBatch/5
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
