﻿using AutoMapper;
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
    public class JournalEntriesController : ControllerBase
    {
        private const int MaxPageSize = 100;
        private readonly IJournalEntryService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<JournalEntriesController> _logger;

        public JournalEntriesController(IUnitOfWorkAsync unitOfWorkAsync, IJournalEntryService service, IMapper mapper, ILogger<JournalEntriesController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/JournalEntries
        [HttpGet(Name = "JournalEntriesList")]
        [Route("PlantStock/{plantStockId}/JournalEntries", Name = "EntriesForStock")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            [FromQuery] int plantStockId)
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
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<JournalEntryDataModel>(lstOfFields);
                }

                var context = _service.Queryable(useTracking: true);

                // TODO: Need to identify if sort field from DTO is in entity or not
                //       to determine if we can sort on projection or need to sort after list is materialised

                var dtos = _mapper
                           .ProjectTo<JournalEntryDataModel>(context, childDtosToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => s.PlantStockId == plantStockId);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Count(),
                    "EntriesForStock",
                    new
                    {
                        sortParams.Sort,
                        plantStockId,
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
                               .Select(dto => DataShaping.CreateDataShapedObject(dto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/JournalEntries/5
        [HttpGet("{id:int}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetById(int id, [FromQuery] DataShapingParameters dsParams)
        {
            try
            {
                //var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    //childDtosToInclude = DataShaping.GetIncludedObjectNames<SpeciesDto>(lstOfFields);
                }

                var item = _service.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDto = _mapper.Map<JournalEntryEntityModel, JournalEntryDataModel>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDto, lstOfFields));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/JournalEntries
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdateJournalEntryDataModel dtoIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<CreateUpdateJournalEntryDataModel, JournalEntryEntityModel>(dtoIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<JournalEntryEntityModel, JournalEntryDataModel>(entity);

                    return CreatedAtAction(nameof(GetById), new { id = dtoOut.Id }, dtoOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/JournalEntries/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdateJournalEntryDataModel dtoIn)
        {
            try
            {
                // Handle mapping failure - where dto is not in right format
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (dtoIn == null)
                {
                    return BadRequest();
                }

                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service.Queryable(useTracking: false).FirstOrDefault(g => g.Id == id);

                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = _mapper.Map<CreateUpdateJournalEntryDataModel, JournalEntryEntityModel>(dtoIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<JournalEntryEntityModel, JournalEntryDataModel>(entity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH: api/JournalEntries/5
        // Partial update
        [HttpPatch("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdateJournalEntryDataModel> itemPatchDoc)
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

                // Map to dto
                var dtoFound = _mapper.Map<JournalEntryEntityModel, CreateUpdateJournalEntryDataModel>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                var updatedEntity = _mapper.Map<CreateUpdateJournalEntryDataModel, JournalEntryEntityModel>(dtoFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<JournalEntryEntityModel, JournalEntryDataModel>(updatedEntity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/JournalEntries/5
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