using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces.WcfService.Responses;

namespace PlantDataMVC.UI.Controllers
{
    public class PlantStockController : DefaultController
    {
        private readonly IPlantStockWcfService _dataService;

        public PlantStockController(IPlantStockWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service or default instance service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantStockDto> response = _dataService.List();

            IList<PlantStockDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockEntryListViewModel>>(View(list));

            return ListView<PlantStockEntryListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override async Task<ActionResult> Show(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDto> response = _dataService.View(id);

            PlantStockDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryShowViewModel>(View(item));
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
        public async Task<ActionResult> Create(PlantStockEntryCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async override Task<ActionResult> Edit(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDto> response = _dataService.View(id);

            PlantStockDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(PlantStockEntryUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            // TODO: check to ensure these DTOs map to view model
            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async override Task<ActionResult> Delete(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDto> response = _dataService.View(id);

            PlantStockDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryDeleteViewModel>(View(item));
        }

        //
        // POST: /Plant/Delete/5
        public async Task<ActionResult> Destroy(PlantStockEntryDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
