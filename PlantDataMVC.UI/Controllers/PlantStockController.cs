using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class PlantStockController : DefaultController
    {
        private IPlantStockWcfService _dataService;

        public PlantStockController(IPlantStockWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service or default instance service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantStockDTO> response = _dataService.List();

            IList<PlantStockDTO> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockEntryListViewModel>>(View(list));

            return ListView<PlantStockEntryListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDTO> response = _dataService.View(id);

            PlantStockDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            PlantStockDTO item = new PlantStockDTO();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryNewViewModel>(View(item));
        }

        /// <summary>
        /// Additional action for creating a new entry for a given species.
        /// </summary>
        /// <param name="speciesId">The Id of the species.</param>
        /// <returns></returns>
        [RequireRequestValue("speciesId")]
        public ActionResult New(int speciesId)
        {
            PlantStockDTO item = new PlantStockDTO();

            item.SpeciesId = speciesId;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(PlantStockEntryCreateEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDTO> response = _dataService.View(id);

            PlantStockDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantStockEntryUpdateEditModel form)
        {
            var success = this.RedirectToAction("Show", new { id = form.Id });

            // TODO: check to ensure these DTOs map to view model
            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<PlantStockDTO> response = _dataService.View(id);

            PlantStockDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockEntryDeleteViewModel>(View(item));
        }

        //
        // POST: /Plant/Delete/5
        public ActionResult Destroy(PlantStockEntryDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
