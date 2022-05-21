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
using PlantDataMVC.WebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMapper _mapper;

        public SpeciesController(IUnitOfWorkAsync unitOfWorkAsync, ISpeciesService service, IMapper mapper)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
            _mapper = mapper;
        }

        // GET: api/Species
        [HttpCacheFactory(300)]
        [HttpGet]
        [Route("", Name = "SpeciesList")]
        [Route("Genus/{genusId}/Species", Name = "SpeciesByGenus")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            [FromQuery] DataShapingParameters dsParams,
            [FromQuery] PagingParameters pgParams,
            [FromQuery] SortingParameters sortParams,
            [FromQuery] int? genusId = null,
            [FromQuery] bool? native = null,
            [FromQuery] string? specificName = null)
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
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<SpeciesDto>(lstOfFields);
                }

                var context = _service.Queryable();

                /*
                // Without DelegateDecompiler, we can't use ProjectTo due to calculated field
                // Less optimal solution means materializing entities then converting list back to queryable
                IEnumerable<SpeciesDto> dtoList = _mapper.Map<IEnumerable<Species>, IEnumerable<SpeciesDto>>(_service.GetAll().ToList());
                IQueryable<SpeciesDto> dtoQueryable = dtoList.AsQueryable();

                var dtos = dtoQueryable
                           .ApplySort(sort)
                           .Where(s => native == null || s.Native == native)
                           .Where(s => specificName == null || s.SpecificName == specificName)
                           .Where(s => genusId == null || s.GenusId == genusId);
                */
                var dtos = _mapper
                           .ProjectTo<SpeciesDto>(context, childDtosToInclude.ToArray())
                           .ApplySort(sortParams.Sort)
                           .Where(s => native == null || s.Native == native)
                           .Where(s => specificName == null || s.SpecificName == specificName)
                           .Where(s => genusId == null || s.GenusId == genusId);

                // HACK: use URL content to determine route used to get here
                // better solution is to add name to data tokens, as per following links
                // https://stackoverflow.com/questions/363211/how-can-i-get-the-route-name-in-controller-in-asp-net-mvc
                // https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/

                var onSpeciesByGenus = HttpContext.Request.Path.ToString().Contains("/Genus/");

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Decompile().Count(),
                    onSpeciesByGenus ? "SpeciesByGenus" : "SpeciesList",
                    new
                    {
                        sortParams.Sort,
                        native,
                        specificName,
                        genusId,
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
                               .Decompile()
                               .ToList()
                               .Select(dto => DataShaping.CreateDataShapedObject(dto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Plant/5
        [HttpCacheFactory(300)]
        [HttpGet("{id:int}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult GetById([FromQuery] int id, [FromQuery] DataShapingParameters dsParams)
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

                var itemDto = _mapper.Map<Species, SpeciesDto>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDto, lstOfFields));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/Plant
        [HttpPost]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Post([FromBody] CreateUpdateSpeciesDto dtoIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = _mapper.Map<CreateUpdateSpeciesDto, Species>(dtoIn);
                _service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Species, SpeciesDto>(entity);

                    return CreatedAtAction(nameof(GetById), new { id = dtoOut.Id }, dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Plant/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Put(int id, [FromBody] CreateUpdateSpeciesDto dtoIn)
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

                var entity = _mapper.Map<CreateUpdateSpeciesDto, Species>(dtoIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Species, SpeciesDto>(entity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH: api/Plant/5
        // Partial update
        [HttpPatch("{id}")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdateSpeciesDto> itemPatchDoc)
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
                var dtoFound = _mapper.Map<Species, CreateUpdateSpeciesDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                var updatedEntity = _mapper.Map<CreateUpdateSpeciesDto, Species>(dtoFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = _mapper.Map<Species, SpeciesDto>(updatedEntity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Plant/5
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
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
