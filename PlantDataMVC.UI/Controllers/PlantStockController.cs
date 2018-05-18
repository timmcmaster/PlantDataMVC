using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.UI.Controllers
{
    public class PlantStockController : DefaultController
    {
        //private IBasicDataService<PlantStockEntry> _dataService;
        private IPlantStockEntryDataService _dataService;

        //public PlantStockController(IBasicDataService<PlantStockEntry> dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        public PlantStockController(IPlantStockEntryDataService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service or default instance service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantStockEntry> response = _dataService.List(new ListRequest<PlantStockEntry>());

            IList<PlantStockEntry> list = response.Items;

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockEntryListViewModel>>(View(list));

            return ListView<PlantStockEntryListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<PlantStockEntry> response = _dataService.View(new ViewRequest<PlantStockEntry>(id));

            PlantStockEntry item = response.Item;

            return AutoMapView<PlantStockEntryShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            PlantStockEntry item = new PlantStockEntry();

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
            PlantStockEntry item = new PlantStockEntry();
            item.SpeciesId = speciesId;

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
            IViewResponse<PlantStockEntry> response = _dataService.View(new ViewRequest<PlantStockEntry>(id));

            PlantStockEntry item = response.Item;

            return AutoMapView<PlantStockEntryEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantStockEntryUpdateEditModel form)
        {
            var success = this.RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<PlantStockEntry> response = _dataService.View(new ViewRequest<PlantStockEntry>(id));

            PlantStockEntry item = response.Item;

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
