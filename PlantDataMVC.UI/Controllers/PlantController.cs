using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public PlantController(IFormHandlerFactory formHandlerFactory) : this(MyHttpClient.GetClient(), formHandlerFactory)
        {
        }

        // Allow passing in HttpClient for unit tests
        public PlantController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            _httpClient = httpClient;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // TODO: Change how paging works
            // retrieving paged data means that paging the returned list does not work as it used to
            // want to get total count from returned response header
            // convert to local 

            // resolve parameters
            var localPage = page ?? 0;
            var localPageSize = pageSize ?? 40;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var httpResponse = await _httpClient.GetAsync("api/Species");

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<SpeciesDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantListViewModel>>(View(model));

                return ListView<PlantListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // GET: /"ControllerName"/Show/5
        public override async Task<ActionResult> Show(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Species/" + id );

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SpeciesDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<List<PlantShowViewModel>>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // Display prior to POST via Create 
        public override ActionResult New()
        {
            var item = new PlantNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        public async Task<ActionResult> Create(PlantCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // Display prior to POST via Update 
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Species/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SpeciesDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(PlantUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // Display prior to DELETE via Destroy method 
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Species/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SpeciesDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // DELETE: /Plant/Delete/5
        public async Task<ActionResult> Destroy(PlantDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
