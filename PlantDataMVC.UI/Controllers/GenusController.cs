using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces.WcfService.Responses;
using Newtonsoft.Json;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI.Controllers
{
    public class GenusController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public GenusController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(),formHandlerFactory)
        {
        }

        // Allow passing in HttpClient for unit tests
        public GenusController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            _httpClient = httpClient;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 0;
            var localPageSize = pageSize ?? 40;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var httpResponse = await _httpClient.GetAsync("api/Genus");

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<GenusInListDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<GenusListViewModel>>(View(model));

                return ListView<GenusListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
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
            var httpResponse = await _httpClient.GetAsync("api/Genus/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<GenusDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<GenusShowViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new GenusNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        public async Task<ActionResult> Create(GenusCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // Display prior to POST via Update 
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Genus/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<GenusDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<GenusEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(GenusUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Genus/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<GenusDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<GenusDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Delete/5
        public async Task<ActionResult> Destroy(GenusDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
