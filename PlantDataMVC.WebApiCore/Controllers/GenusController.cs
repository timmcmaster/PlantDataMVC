using AutoMapper;
using DelegateDecompiler;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApiCore.Helpers;
using PlantDataMVC.WebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default5mins")]
    public class GenusController : ControllerBase
    {
        private readonly IGenusService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;
        private readonly ILogger<GenusController> _logger;

        public GenusController(IUnitOfWorkAsync unitOfWorkAsync, IGenusService service, IMapper mapper, ILogger<GenusController> logger)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Genus
        [HttpGet(Name = "GenusList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            [FromQuery] string? latinName = null
           )
        {
            try
            {
                var childDtosToInclude = new List<string>();

                // Convert fields to list of fields
                var lstOfFields = new List<string>();

                if (dsParams.Fields != null)
                {
                    lstOfFields = dsParams.Fields.Split(',').ToList();
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<GenusDto>(lstOfFields);
                }

                var context = _service.Queryable();

                /*
                // Without DelegateDecompiler, we can't use ProjectTo due to calculated field in Species
                // Less optimal solution means evaluating query then converting list back to queryable
                IList<GenusDto> dtoList = _mapper.Map<IList<Genus>, IList<GenusDto>>(_service.GetAll().ToList());
                IQueryable<GenusDto> dtoQueryable = dtoList.AsQueryable();
                
                var dtos = dtoQueryable
                           .ApplySort(sort)
                           .Where(s => latinName == null || s.LatinName == latinName);
                */

                //var dtos = context
                //           .ProjectTo<GenusDto>(null, childDtosToInclude.ToArray())
                //           .ApplySort(sortParams.Sort)
                //           .Where(s => latinName == null || s.LatinName == latinName);

                var dtos = _mapper.ProjectTo<GenusDto>(context, childDtosToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => latinName == null || s.LatinName == latinName);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Decompile().Count(),
                    "GenusList",
                    new
                    {
                        sortParams.Sort
                    },
                    pgParams.Page,
                    pgParams.PageSize);

                foreach (var hdr in paginationHeaders)
                {
                    HttpContext.Response.Headers.Add(hdr);
                }

                var itemList = dtos
                               .Paginate(pgParams.Page, pgParams.PageSize)
                               .Decompile()
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

        // GET: api/Genus/5
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

                var itemDto = _mapper.Map<Genus, GenusDto>(item);

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

        // POST: api/Genus
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdateGenusDto dtoIn)
        {
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);

                // Check for unique genus
                if (_service.GetItemByLatinName(entity.LatinName) != null)
                {
                    return BadRequest("Genus already exists" + entity.LatinName);
                }

                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Genus, GenusDto>(entity);

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

        // PUT: api/Genus/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdateGenusDto dtoIn)
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
                var entityFound = _service.QueryableAsNoTracking().FirstOrDefault(g => g.Id == id);

                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = _mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Genus, GenusDto>(entity);

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


        // PATCH: api/Genus/5
        // Partial update
        [HttpPatch("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdateGenusDto> itemPatchDoc)
        {
            try
            {
                if (itemPatchDoc == null)
                {
                    return BadRequest();
                }

                // Get domain entity
                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _service.QueryableAsNoTracking().FirstOrDefault(g => g.Id == id);

                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dto
                var dtoFound = _mapper.Map<Genus, CreateUpdateGenusDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                var updatedEntity = _mapper.Map<CreateUpdateGenusDto, Genus>(dtoFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Genus, GenusDto>(updatedEntity);

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

        // DELETE: api/Genus/5
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
