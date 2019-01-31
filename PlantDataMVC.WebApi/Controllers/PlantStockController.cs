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
using Interfaces.DAL.UnitOfWork;
using Marvin.JsonPatch;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApi.Helpers;

namespace PlantDataMVC.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class PlantStockController : ApiController
    {
        private const int MaxPageSize = 100;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IPlantStockService _service;

        public PlantStockController(IUnitOfWorkAsync unitOfWorkAsync,
            IPlantStockService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/PlantStock
        [HttpCache(DefaultExpirySeconds = 300)]
        [HttpGet]
        [Route("PlantStock", Name = "PlantStockList")]
        public IHttpActionResult Get(
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

                IQueryable<PlantStockDto> dtos = context
                    .ProjectTo<PlantStockDto>(null, childDtosToInclude.ToArray())
                    .ApplySort(sort)
                    .Where(s => (speciesId == null || s.SpeciesId == speciesId))
                    .Where(s => (productTypeId == null || s.ProductTypeId == productTypeId));

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos,
                    "PlantStockList",
                    new
                    {
                        sort = sort,
                        speciesId = speciesId,
                        productTypeId = productTypeId,
                        fields = fields
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
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // GET: api/Plant/5
        [HttpCache(DefaultExpirySeconds = 300)]
        [Route("PlantStock/{id}")]
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
                    //childDtosToInclude = DataShaping.GetIncludedObjectNames<PlantStockDto>(lstOfFields);
                }

                var item = _service.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }

                var itemDto = Mapper.Map<PlantStock, PlantStockDto>(item);

                return Ok(DataShaping.CreateDataShapedObject(itemDto, lstOfFields));
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            // if bad request, return 400
            //return BadRequest();
        }

        // POST: api/Plant
        [Route("PlantStock")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CreateUpdatePlantStockDto dtoIn)
        {
            // TODO: Add validation checks (e.g. uniqueness)
            try
            {
                if (dtoIn == null)
                {
                    return BadRequest();
                }

                var entity = Mapper.Map<CreateUpdatePlantStockDto, PlantStock>(dtoIn);

                var returnEntity =_service.Add(entity);

                // Save changes before we map back
                var changes = _unitOfWorkAsync.SaveChanges();

                // Check for errors from service
                if (changes > 0)
                {
                    var dtoOut = Mapper.Map<PlantStock, PlantStockDto>(entity);

                    var location = Request.RequestUri + "/" + dtoOut.Id;
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
        [Route("PlantStock/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]CreateUpdatePlantStockDto dtoIn)
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

                var returnEntity = _service.Save(entity);

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
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PATCH: api/Plant/5
        // Partial update
        [Route("PlantStock/{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<CreateUpdatePlantStockDto> itemPatchDoc)
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

                var returnEntity = _service.Save(updatedEntity);

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
                return InternalServerError();
            }
        }

        // DELETE: api/Plant/5
        [Route("PlantStock/{id}")]
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