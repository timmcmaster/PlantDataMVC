using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Web.Mvc;
using PlantDataMVC.DTO.Dtos;


namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : DefaultController
    {
        private ISpeciesWcfService _dataService;

        public PlantController(ISpeciesWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            int localPage = page ?? 0;
            int localPageSize = pageSize ?? 40;
            string localSortBy = sortBy ?? string.Empty;
            bool localAscending = ascending ?? true;

            var response = _dataService.List();

            var list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantListViewModel>>(View(list));

            return ListView<PlantListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            var response = _dataService.View(id);

            var item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/Show/5
        public ActionResult ShowBasic(int id)
        {
            // return view for Model
            var response = _dataService.View(id);

            var item = response.Item;

            return View(item);
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new SpeciesDto();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(PlantCreateEditModel form)
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
            return AutoMapView<PlantEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantUpdateEditModel form)
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
            return AutoMapView<PlantDeleteViewModel>(View(item));
        }

        //
        // POST: /Plant/Delete/5
        public ActionResult Destroy(PlantDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
