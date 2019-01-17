using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class TrayController : DefaultController
    {
        private ISeedTrayWcfService _dataService;

        public TrayController(ISeedTrayWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            var response = _dataService.List();

            var list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<TrayListViewModel>>(View(list));

            return ListView<TrayListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            var response = _dataService.View(id);

            var item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new SeedTrayDto();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayNewViewModel>(View(item));
        }

        /// <summary>
        /// Additional action for creating a new seed tray entry for a given seed batch.
        /// </summary>
        /// <param name="seedBatchId">The Id of the seed batch.</param>
        /// <returns></returns>
        [RequireRequestValue("seedBatchId")]
        public ActionResult New(int seedBatchId)
        {
            var item = new SeedTrayDto();
            item.SeedBatchId = (int)seedBatchId;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(TrayCreateEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            var response = _dataService.View(id);

            var item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(TrayUpdateEditModel form)
        {
            var success = this.RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            var response = _dataService.View(id);

            var item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayDeleteViewModel>(View(item));
        }

        //
        // POST: /SeedTrayDTO/Delete/5
        public ActionResult Destroy(TrayDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
