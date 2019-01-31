using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
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

namespace PlantDataMVC.UI.Controllers
{
    public class TransactionController : DefaultController
    {
        private readonly HttpClient _httpClient;

        public TransactionController(IFormHandlerFactory formHandlerFactory) : this(PlantDataApiHttpClient.GetClient(), formHandlerFactory)
        {
        }

        // Allow passing in HttpClient for unit tests
        public TransactionController(HttpClient httpClient, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            _httpClient = httpClient;
        }

/*
        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            IListResponse<JournalEntryDto> response = _dataService.List();

            IList<JournalEntryDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockTransactionListViewModel>>(View(list));

            return ListView<PlantStockTransactionListViewModel>(autoMapResult, localPage, localPageSize, localSortBy, localAscending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async override Task<ActionResult> Show(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionShowViewModel>(View(item));
        }
*/
/*
        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new PlantStockTransactionNewViewModel();
            return View(item);
        }
*/
        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        //[RequireRequestValue("plantStockId")]
        public ActionResult New(int plantStockId)
        {
            var item = new JournalEntryDto {PlantStockId = plantStockId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantStockTransactionCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/JournalEntries/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<JournalEntryDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantStockTransactionEditViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PlantStockTransactionUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var httpResponse = await _httpClient.GetAsync("api/JournalEntries/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<JournalEntryDto>(content);

                // TODO: check to ensure these DTOs map to view model
                return AutoMapView<PlantStockTransactionDeleteViewModel>(View(model));
            }
            else
            {
                return Content("An error occurred");
            }
        }

        //
        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantStockTransactionDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
