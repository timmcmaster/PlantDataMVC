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
    public class SeedController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public SeedController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(), formHandlerFactory)
        {
        }

        // Allow passing in HttpClient for unit tests
        public SeedController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            _httpClient = httpClient;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var httpResponse = await _httpClient.GetAsync("api/SeedBatch?page=" + localPage + "&pageSize=" + localPageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var model = JsonConvert.DeserializeObject<IEnumerable<SeedBatchDto>>(content);

                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantSeedListViewModel>>(View(model));

                return ListView<PlantSeedListViewModel>(autoMapResult, apiPagingInfo, localSortBy, localAscending);
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
            var httpResponse = await _httpClient.GetAsync("api/SeedBatch/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedBatchDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantSeedShowViewModel>(View(model));
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
            var item = new PlantSeedNewViewModel();
            return View(item);
        }

        /// <summary>
        /// Additional action for creating a new entry for a given species.
        /// </summary>
        /// <param name="speciesId">The Id of the species.</param>
        /// <returns></returns>
        [RequireRequestValue("speciesId")]
        public ActionResult New(int speciesId)
        {
            var item = new SeedBatchDto {SpeciesId = speciesId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantSeedCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/SeedBatch/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedBatchDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantSeedEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PlantSeedUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/SeedBatch/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedBatchDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantSeedDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /Seed/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantSeedDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
