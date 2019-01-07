using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantController : ApiController
    {
        private IPlantDataService _dataService;

        public PlantController(IPlantDataService dataService) : base()
        {
            // use passed in service
            _dataService = dataService;
        }

        // General codes
        // 401 unauthorized
        // 403 forbidden
        // 405 unauthorized

        // GET: api/Plant
        public IHttpActionResult Get()
        {
            try
            {
                // TODO: want data service to return list, rather than ListResponse
                var response = _dataService.List();
                var items = response.Items;

                return Ok(items);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Plant/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                // TODO: want data service to return list, rather than ListResponse
                var response = _dataService.View(id);
                var item = response.Item;

                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(item);
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
        public IHttpActionResult Post([FromBody]Plant plant)
        {
            try
            {
                if (plant == null)
                {
                    return BadRequest();
                }

                var response = _dataService.Create(plant);
                
                // Check for errors from service
                // TODO: Add error handling in service so that FK issues give bad request, not exception and 500 error
                if (response.ErrorCode == 0)
                {
                    var createdItem = response.Item;

                    var location = Request.RequestUri + "/" + createdItem.Id.ToString();
                    return Created(location, createdItem);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
/*
        // PUT: api/Plant/5
        // Should be FULL update only (i.e. all fields, or default values if not supplied)
        public IHttpActionResult Put(int id, [FromBody]Plant plant)
        {
            // if bad request, return 400
            //return BadRequest();

            // if error on api side return 500
            //return InternalServerError();

            // if can't find id, return 404
            //return NotFound();

            return Ok();
        }

        // PATCH: api/Plant/5
        // Partial update
        public IHttpActionResult Patch(int id, [FromBody]Plant plant)
        {
            // if bad request, return 400
            //return BadRequest();

            // if error on api side return 500
            //return InternalServerError();

            // if can't find id, return 404
            //return NotFound();

            return Ok();
        }

        // DELETE: api/Plant/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var response = _dataService.Delete(id);

                // Check response from service
                if (response.ErrorCode == 0)
                {
                    // return 204 (also via void return type)
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    // handled error occurred (assuming  = not found for now)
                    return NotFound();
                }


                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        */
    }
}
