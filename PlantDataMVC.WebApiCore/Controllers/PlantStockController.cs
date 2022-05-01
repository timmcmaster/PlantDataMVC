using AutoMapper;
using AutoMapper.QueryableExtensions;
using CacheCow.Server.Core.Mvc;
using DelegateDecompiler;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApiCore.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantStockController : ControllerBase
    {
        private const int MaxPageSize = 100;
        private readonly IPlantStockService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public PlantStockController(IUnitOfWorkAsync unitOfWorkAsync, IPlantStockService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/PlantStock
        [HttpCacheFactory(300)]
        [HttpGet(Name = "PlantStockList")]
        [Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            int? speciesId = null,
            int? productTypeId = null,
            string sort = "id",
            int page = 1, int pageSize = MaxPageSize,
            string fields = null)
        {
            try
            {
                // TODO: Current state doesn't return children by default, can only get with "fields" option
                // need to determine expected behaviour

                var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.Split(',').ToList();
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<PlantStockDto>(lstOfFields);
                }

                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                var context = _service.Queryable();

                var dtos = context
                           .ProjectTo<PlantStockDto>(null, childDtosToInclude.ToArray())
                           .ApplySort(sort)
                           .Where(s => speciesId == null || s.SpeciesId == speciesId)
                           .Where(s => productTypeId == null || s.ProductTypeId == productTypeId);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Count(),
                    "PlantStockList",
                    new
                    {
                        sort,
                        speciesId,
                        productTypeId,
                        fields
                    },
                    page,
                    pageSize);

                foreach (var hdr in paginationHeaders)
                {
                    HttpContext.Response.Headers.Add(hdr);
                }

                var itemList = dtos
                               .Paginate(page, pageSize)
                               .ToList()
                               .Select(dto => DataShaping.CreateDataShapedObject(dto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/PlantStock/5
        [HttpCacheFactory(300)]
        [HttpGet("{id}")]
        [Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetById(int id, string fields = null)
        {
            try
            {
                var includeJournalEntries = false;
                //var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.Split(',').ToList();

                    var childDtosToInclude =
                        DataShaping.GetIncludedObjectNames<PlantStockDto>(lstOfFields); // needed if using projectTo

                    includeJournalEntries = childDtosToInclude.Contains("JournalEntries");
                }

                PlantStock item;

                if (includeJournalEntries)
                {
                    try
                    {
                        item = _service.Query(s => s.Id == id).Include(p => p.JournalEntries).Select().Single();
                    }
                    catch (InvalidOperationException
                    ) // thrown by single if more than one element, no elements, or empty list
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

                var itemDto = Mapper.Map<PlantStock, PlantStockDto>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDto, lstOfFields));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/PlantStock
        [HttpPost]
        [Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdatePlantStockDto dtoIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdatePlantStockDto, PlantStock>(dtoIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<PlantStock, PlantStockDto>(entity);

                    return CreatedAtAction(nameof(GetById), new { id = dtoOut.Id }, dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/PlantStock/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        [Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdatePlantStockDto dtoIn)
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
                var entityFound = _service.Queryable().AsNoTracking().FirstOrDefault(g => g.Id == id);

                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = Mapper.Map<CreateUpdatePlantStockDto, PlantStock>(dtoIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<PlantStock, PlantStockDto>(entity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH: api/PlantStock/5
        // Partial update
        [HttpPatch("{id}")]
        [Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdatePlantStockDto> itemPatchDoc)
        {
            try
            {
                if (itemPatchDoc == null)
                {
                    return BadRequest();
                }

                // Get domain entity
                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service.Queryable().AsNoTracking().FirstOrDefault(g => g.Id == id);

                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dto
                var dtoFound = Mapper.Map<PlantStock, CreateUpdatePlantStockDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                var updatedEntity = Mapper.Map<CreateUpdatePlantStockDto, PlantStock>(dtoFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<PlantStock, PlantStockDto>(updatedEntity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/PlantStock/5
        [HttpDelete("{id}")]
        [Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
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
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
