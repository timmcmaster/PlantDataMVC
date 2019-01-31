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
    public class TrayController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public TrayController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(), formHandlerFactory)
        {
        }

        public TrayController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
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

            var httpResponse = await _httpClient.GetAsync("api/SeedTray?page=" + localPage + "&pageSize=" + localPageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var model = JsonConvert.DeserializeObject<IEnumerable<SeedTrayDto>>(content);

                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<TrayListViewModel>>(View(model));

                return ListView<TrayListViewModel>(autoMapResult, apiPagingInfo, localSortBy, localAscending);
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
            var httpResponse = await _httpClient.GetAsync("api/SeedTray/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<TrayShowViewModel>(View(model));
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
            var item = new TrayNewViewModel();
            return View(item);
        }

        /// <summary>
        /// Additional action for creating a new seed tray entry for a given seed batch.
        /// </summary>
        /// <param name="seedBatchId">The Id of the seed batch.</param>
        /// <returns></returns>
        [RequireRequestValue("seedBatchId")]
        public ActionResult New(int seedBatchId)
        {
            var item = new SeedTrayDto {SeedBatchId = seedBatchId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TrayCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/SeedTray/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<TrayEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TrayUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/SeedTray/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<TrayDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /SeedTrayDTO/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(TrayDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
