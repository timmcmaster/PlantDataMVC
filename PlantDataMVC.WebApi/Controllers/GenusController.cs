﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CacheCow.Server.WebApi;
using Interfaces.DAL.UnitOfWork;
using Marvin.JsonPatch;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApi.Helpers;

namespace PlantDataMVC.WebApi.Controllers
{
    [RoutePrefix("api")]
    [Authorize]
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

                //IList<GenusDto> itemList = context
                //    .ProjectTo<GenusDto>()
                //    .ApplySort(sort)
                //    .ToList();

                var dtos = context
                           .ProjectTo<GenusDto>(null, childDtosToInclude.ToArray())
                           .ApplySort(sort)
                           .Where(s => latinName == null || s.LatinName == latinName);

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos,
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
                               .ToList()
                               .Select(dto => DataShaping.CreateDataShapedObject(dto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Plant/5
        [HttpGet]
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
        public IHttpActionResult Post([FromBody] CreateUpdateGenusDto dtoIn)
        {
            // TODO: Add check for unique genus
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);
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
                _service.Save(entity);

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
                _service.Save(updatedEntity);

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