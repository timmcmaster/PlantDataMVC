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
    public class PlantStockController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public PlantStockController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(), formHandlerFactory)
        {
        }

        // Allow passing in HttpClient for unit tests
        public PlantStockController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
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

            var httpResponse = await _httpClient.GetAsync("api/PlantStock&page=" + localPage + "&pageSize=" + localPageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var model = JsonConvert.DeserializeObject<IEnumerable<PlantStockDto>>(content);

                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockEntryListViewModel>>(View(model));

                return ListView<PlantStockEntryListViewModel>(autoMapResult, apiPagingInfo, localSortBy, localAscending);
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
            var httpResponse = await _httpClient.GetAsync("api/PlantStock/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<PlantStockDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantStockEntryShowViewModel>(View(model));
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
            var item = new PlantStockEntryNewViewModel();
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
            var item = new PlantStockDto {SpeciesId = speciesId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantStockEntryCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/PlantStock/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<PlantStockDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantStockEntryEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PlantStockEntryUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            // TODO: check to ensure these DTOs map to view model
            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/PlantStock/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<PlantStockDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantStockEntryDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /Plant/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantStockEntryDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
