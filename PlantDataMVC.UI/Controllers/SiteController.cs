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
    public class SiteController : DefaultController
    {
        private ISiteWcfService _dataService;

        public SiteController(ISiteWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<SiteDTO> response = _dataService.List();

            IList<SiteDTO> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<SiteListViewModel>>(View(list));

            return ListView<SiteListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<SiteDTO> response = _dataService.View(id);

            SiteDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            SiteDTO item = new SiteDTO();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(SiteCreateEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<SiteDTO> response = _dataService.View(id);

            SiteDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(SiteUpdateEditModel form)
        {
            var success = this.RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<SiteDTO> response = _dataService.View(id);

            SiteDTO item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteDeleteViewModel>(View(item));
        }

        //
        // POST: /Seed/Delete/5
        public ActionResult Destroy(SiteDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
