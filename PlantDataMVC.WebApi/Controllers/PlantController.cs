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

        // GET: api/Plant
        public IEnumerable<Plant> Get()
        {
            return _dataService.List().Items;
        }

        // GET: api/Plant/5
        public IHttpActionResult Get(int id)
        {
            Plant plant = _dataService.View(id).Item;
            // if bad request, return 400
            //return BadRequest();

            // if error on api side return 500
            //return InternalServerError();

            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        // POST: api/Plant
        public IHttpActionResult Post([FromBody]Plant plant)
        {
            Plant createdPlant = _dataService.Create(plant).Item;
            // if bad request, return 400
            //return BadRequest();

            // if error on api side return 500
            //return InternalServerError();
            
            // return 201
            var location = "";
            return Created(location, createdPlant);
        }

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
            // if bad request, return 400
            //return BadRequest();

            // if error on api side return 500
            //return InternalServerError();

            // if can't find id, return 404
            //return NotFound();

            // return 204 (also via void return type)
            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
