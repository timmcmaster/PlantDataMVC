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
    public class TrayController : DefaultController
    {
        //private IDataServiceBase<PlantSeedTray> _dataService;
        private IPlantSeedTrayDataService _dataService;

        //public TrayController(IDataServiceBase<PlantSeedTray> dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        public TrayController(IPlantSeedTrayDataService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantSeedTray> response = _dataService.List(new ListRequest<PlantSeedTray>());

            IList<PlantSeedTray> list = response.Items;

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<TrayListViewModel>>(View(list));

            return ListView<TrayListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<PlantSeedTray> response = _dataService.View(new ViewRequest<PlantSeedTray>(id));

            PlantSeedTray item = response.Item;

            return AutoMapView<TrayShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            PlantSeedTray item = new PlantSeedTray();

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
            PlantSeedTray item = new PlantSeedTray();
            item.SeedBatchId = (int)seedBatchId;

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
            IViewResponse<PlantSeedTray> response = _dataService.View(new ViewRequest<PlantSeedTray>(id));

            PlantSeedTray item = response.Item;

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
            IViewResponse<PlantSeedTray> response = _dataService.View(new ViewRequest<PlantSeedTray>(id));

            PlantSeedTray item = response.Item;

            return AutoMapView<TrayDeleteViewModel>(View(item));
        }

        //
        // POST: /PlantSeedTray/Delete/5
        public ActionResult Destroy(TrayDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
