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
    public class SiteController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public SiteController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(), formHandlerFactory)
        {
        }
        public SiteController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
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

            var httpResponse = await _httpClient.GetAsync("api/Site?page=" + localPage + "&pageSize=" + localPageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var model = JsonConvert.DeserializeObject<IEnumerable<SiteDto>>(content);

                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<SiteListViewModel>>(View(model));

                return ListView<SiteListViewModel>(autoMapResult, apiPagingInfo, localSortBy, localAscending);
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
            var httpResponse = await _httpClient.GetAsync("api/Site/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SiteDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<SiteShowViewModel>(View(model));
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
            var item = new SiteNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SiteCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Site/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SiteDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<SiteEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(SiteUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/Site/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<SiteDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<SiteDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /Seed/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(SiteDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
