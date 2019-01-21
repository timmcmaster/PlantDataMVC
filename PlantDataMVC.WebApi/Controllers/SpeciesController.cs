using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interfaces.DAL.UnitOfWork;
using Marvin.JsonPatch;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PlantDataMVC.WebApi.Controllers
{
    public class SpeciesController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ISpeciesService _service;

        public SpeciesController(IUnitOfWorkAsync unitOfWorkAsync,
            ISpeciesService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Species
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var context = _service.Queryable();
                IList<SpeciesInListDto> itemList = context.ProjectTo<SpeciesInListDto>().ToList();

                return Ok(itemList);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Plant/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var item = _service.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    SpeciesDto finalItem = Mapper.Map<Species, SpeciesDto>(item);
                    return Ok(finalItem);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/Plant
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateUpdateSpeciesDto dtoIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdateSpeciesDto, Species>(dtoIn);

                var returnEntity =_service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    SpeciesDto dtoOut = Mapper.Map<Species, SpeciesDto>(entity);

                    var location = Request.RequestUri + "/" + dtoOut.Id.ToString();
                    return Created(location, dtoOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Plant/5
        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]CreateUpdateSpeciesDto dtoIn)
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

                var entity = Mapper.Map<CreateUpdateSpeciesDto, Species>(dtoIn);
                entity.Id = entityFound.Id;

                var returnEntity = _service.Save(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    SpeciesDto dtoOut = Mapper.Map<Species, SpeciesDto>(entity);

                    return Ok(dtoOut);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PATCH: api/Plant/5
        // Partial update
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<CreateUpdateSpeciesDto> itemPatchDoc)
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
                CreateUpdateSpeciesDto dtoFound = Mapper.Map<Species, CreateUpdateSpeciesDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                Species updatedEntity = Mapper.Map<CreateUpdateSpeciesDto, Species>(dtoFound);
                updatedEntity.Id = id;

                var returnEntity = _service.Save(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    SpeciesDto dtoOut = Mapper.Map<Species, SpeciesDto>(updatedEntity);

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
