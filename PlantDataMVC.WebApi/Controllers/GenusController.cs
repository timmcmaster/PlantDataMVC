using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service;
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
using Interfaces.DAL.Infrastructure;

namespace PlantDataMVC.WebApi.Controllers
{
    public class GenusController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IGenusService _genusService;

        public GenusController(IUnitOfWorkAsync unitOfWorkAsync,
            IGenusService genusService)
        {
            _genusService = genusService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Genus
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var context = _genusService.Queryable();
                IList<GenusDto> itemList = context.ProjectTo<GenusDto>().ToList();

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
                var item = _genusService.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    GenusDto finalItem = Mapper.Map<Genus, GenusDto>(item);
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
        public IHttpActionResult Post([FromBody]CreateUpdateGenusDto dtoIn)
        {
            // TODO: Add check for unique genus
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);

                var returnEntity =_genusService.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    GenusDto dtoOut = Mapper.Map<Genus, GenusDto>(entity);

                    var location = Request.RequestUri + "/" + dtoOut.Id.ToString();
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
        public IHttpActionResult Put(int id, [FromBody]CreateUpdateGenusDto dtoIn)
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
                var entityFound = _genusService.Queryable().AsNoTracking().FirstOrDefault(g => g.Id == id);
                if (entityFound == null)
                {
                    return NotFound();
                }

                var entity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoIn);
                entity.Id = entityFound.Id;

                var returnEntity = _genusService.Save(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    GenusDto dtoOut = Mapper.Map<Genus, GenusDto>(entity);

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
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<CreateUpdateGenusDto> itemPatchDoc)
        {
            try
            {
                if (itemPatchDoc == null)
                {
                    return BadRequest();
                }

                // Get domain entity
                // Find id without tracking to prevent attaching object (and hence problem when attaching via save)
                var entityFound = _genusService.Queryable().AsNoTracking().FirstOrDefault(g => g.Id == id);
                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                // Map to dto
                CreateUpdateGenusDto dtoFound = Mapper.Map<Genus, CreateUpdateGenusDto>(entityFound);

                // Apply changes to dto
                itemPatchDoc.ApplyTo(dtoFound);

                Genus updatedEntity = Mapper.Map<CreateUpdateGenusDto, Genus>(dtoFound);
                updatedEntity.Id = id;

                var returnEntity = _genusService.Save(updatedEntity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    GenusDto dtoOut = Mapper.Map<Genus, GenusDto>(updatedEntity);

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
                var entityFound = _genusService.GetItemById(id);

                // Check for errors from service
                if (entityFound == null)
                {
                    return NotFound();
                }

                _genusService.Delete(entityFound);
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
