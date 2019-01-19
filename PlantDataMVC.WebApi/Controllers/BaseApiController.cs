//using Interfaces.Domain;
//using Interfaces.Service;
//using Marvin.JsonPatch;
//using PlantDataMVC.Domain.Entities;
//using PlantDataMVC.Service.ServiceContracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Interfaces.DAL.Entity;

//namespace PlantDataMVC.WebApi.Controllers
//{
//    public class BaseApiController<TEntity> : ApiController where TEntity : class, IEntity
//    {
//        private IDataServiceBase<T> _dataService;

//        public BaseApiController(IDataServiceBase<T> dataService) : base()
//        {
//            // use passed in service
//            _dataService = dataService;
//        }

//        // GET: api/Plant
//        public IHttpActionResult Get()
//        {
//            try
//            {
//                // TODO: want data service to return list, rather than ListResponse
//                var response = _dataService.List();
//                var items = response.Items;

//                return Ok(items);
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }

//        // GET: api/Plant/5
//        public IHttpActionResult Get(int id)
//        {
//            try
//            {
//                // TODO: want data service to return list, rather than ListResponse
//                var response = _dataService.View(id);
//                var item = response.Item;

//                if (item == null)
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    return Ok(item);
//                }
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }

//            // if bad request, return 400
//            //return BadRequest();
//        }

//        // POST: api/Plant
//        [HttpPost]
//        public IHttpActionResult Post([FromBody]T item)
//        {
//            try
//            {
//                if (item == null)
//                {
//                    return BadRequest();
//                }

//                var response = _dataService.Create(item);
                
//                // Check for errors from service
//                if (response.Status == ServiceActionStatus.Created)
//                {
//                    var createdItem = response.Item;

//                    var location = Request.RequestUri + "/" + createdItem.Id.ToString();
//                    return Created(location, createdItem);
//                }

//                return BadRequest();
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }

//        // PUT: api/Plant/5
//        // TODO: Make underlying operation FULL update only (i.e. all stored fields, or default values if not supplied)
//        public IHttpActionResult Put(int id, [FromBody]T item)
//        {
//            try
//            {
//                if ((item == null) || (id != item.Id))
//                {
//                    return BadRequest();
//                }

//                var response = _dataService.Update(id, item);

//                // Check for errors from service
//                if (response.Status == ServiceActionStatus.Updated)
//                {
//                    var updatedItem = response.Item;

//                    return Ok(updatedItem);
//                }
//                else if (response.Status == ServiceActionStatus.NotFound)
//                {
//                    return NotFound();
//                }

//                return BadRequest();
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }

//        // PATCH: api/Plant/5
//        // Partial update
//        [HttpPatch]
//        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<T> itemPatchDoc)
//        {
//            try
//            {
//                if (itemPatchDoc == null)
//                {
//                    return BadRequest();
//                }

//                // Get domain entity
//                var viewResponse = _dataService.View(id);

//                // Check for errors from service
//                if (viewResponse.Status == ServiceActionStatus.NotFound)
//                {
//                    return NotFound();
//                }

//                // TODO: Fix needed, as uow is disposed of afer View operation, causing errors below
                
//                // Apply changes to domain entity
//                var viewItem = viewResponse.Item;
//                itemPatchDoc.ApplyTo(viewItem);

//                var updateResponse = _dataService.Update(viewItem.Id, viewItem);

//                if (updateResponse.Status == ServiceActionStatus.Updated)
//                {
//                    return Ok(updateResponse.Item);
//                }

//                return BadRequest();
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }

//        // DELETE: api/Plant/5
//        public IHttpActionResult Delete(int id)
//        {
//            try
//            {
//                var response = _dataService.Delete(id);

//                // Check response from service
//                if (response.Status == ServiceActionStatus.Deleted)
//                {
//                    // return 204 (also via void return type)
//                    return StatusCode(HttpStatusCode.NoContent);
//                }
//                else if (response.Status == ServiceActionStatus.NotFound)
//                {
//                    // handled error occurred (assuming  = not found for now)
//                    return NotFound();
//                }

//                return BadRequest();
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }
//    }
//}
