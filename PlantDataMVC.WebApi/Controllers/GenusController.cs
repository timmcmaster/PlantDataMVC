using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CacheCow.Server.WebApi;
using DelegateDecompiler;
using Interfaces.Domain.UnitOfWork;
using Marvin.JsonPatch;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApi.Helpers;
using Thinktecture.IdentityModel.WebApi;

namespace PlantDataMVC.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class GenusController : ApiController
    {
        private const int MaxPageSize = 100;
        private readonly IGenusService _service;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public GenusController(IUnitOfWorkAsync unitOfWorkAsync, IGenusService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Genus
        [HttpCache(DefaultExpirySeconds = 300)]
        [HttpGet]
        [Route("Genus", Name = "GenusList")]
        [ResourceAuthorize("Read", "Genus")]
        public IHttpActionResult Get(
            string sort = "id",
            string latinName = null,
            int page = 1, int pageSize = MaxPageSize,
            string fields = null)
        {
            try
            {
                var childDtosToInclude = new List<string>();

                // Convert fields to list of fields
                var lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.Split(',').ToList();
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<GenusDto>(lstOfFields);
                }

                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                var context = _service.Queryable();

                /*
                // Without DelegateDecompiler, we can't use ProjectTo due to calculated field in Species
                // Less optimal solution means evaluating query then converting list back to queryable
                IList<GenusDto> dtoList = Mapper.Map<IList<Genus>, IList<GenusDto>>(_service.GetAll().ToList());
                IQueryable<GenusDto> dtoQueryable = dtoList.AsQueryable();
                
                var dtos = dtoQueryable
                           .ApplySort(sort)
                           .Where(s => latinName == null || s.LatinName == latinName);
                */

                var dtos = context
                           .ProjectTo<GenusDto>(null, childDtosToInclude.ToArray())
                           .ApplySort(sort)
                           .Where(s => latinName == null || s.LatinName == latinName);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Decompile().Count(),
                    "GenusList",
                    new
                    {
                        sort
                    },
                    page,
                    pageSize);

                HttpContext.Current.Response.Headers.Add(paginationHeaders);

                var itemList = dtos
                               .Paginate(page, pageSize)
                               .Decompile()
                               .ToList()
                               .Select(dto => DataShaping.CreateDataShapedObject(dto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // GET: api/Plant/5
        [HttpGet]
        [ResourceAuthorize("Read", "Genus")]
        public IHttpActionResult Get(int id, string fields = null)
        {
            try
            {
                //var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.Split(',').ToList();
                    //childDtosToInclude = DataShaping.GetIncludedObjectNames<SpeciesDto>(lstOfFields);
                }

                var item = _service.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDto = Mapper.Map<Genus, GenusDto>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDto, lstOfFields));
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/Genus
        [Route("Genus")]
        [HttpPost]
        [ResourceAuthorize("Write", "Genus")]
        public IHttpActionResult Post([FromBody] CreateUpdateGenusDto dtoIn)
        {
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);

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
                    var dtoOut = Mapper.Map<Genus, GenusDto>(entity);

                    var location = Request.RequestUri + "/" + dtoOut.Id;
                    return Created(location, dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Plant/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut]
        [ResourceAuthorize("Write", "Genus")]
        public IHttpActionResult Put(int id, [FromBody] CreateUpdateGenusDto dtoIn)
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

                var entity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);
                entity.Id = entityFound.Id;
                _service.Update(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<Genus, GenusDto>(entity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // PATCH: api/Plant/5
        // Partial update
        [HttpPatch]
        [ResourceAuthorize("Write", "Genus")]
        public IHttpActionResult Patch(int id, [FromBody] JsonPatchDocument<CreateUpdateGenusDto> itemPatchDoc)
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

                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dto
                var dtoFound = Mapper.Map<Genus, CreateUpdateGenusDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                var updatedEntity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoFound);
                updatedEntity.Id = id;
                _service.Update(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<Genus, GenusDto>(updatedEntity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Plant/5
        [HttpDelete]
        [ResourceAuthorize("Write", "Genus")]
        public IHttpActionResult Delete(int id)
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
                return StatusCode(HttpStatusCode.NoContent);


                //return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
 