using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.UI.Controllers
{
    public class SiteController : DefaultController
    {
        private IPlantSeedSiteDataService _dataService;

        public SiteController(IPlantSeedSiteDataService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantSeedSite> response = _dataService.List();

            IList<PlantSeedSite> list = response.Items;

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<SiteListViewModel>>(View(list));

            return ListView<SiteListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<PlantSeedSite> response = _dataService.View(id);

            PlantSeedSite item = response.Item;

            return AutoMapView<SiteShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            PlantSeedSite item = new PlantSeedSite();

            return AutoMapView<SiteNewViewModel>(View(item));
        }

        ///// <summary>
        ///// Additional action for creating a new entry for a given species.
        ///// </summary>
        ///// <param name="speciesId">The Id of the species.</param>
        ///// <returns></returns>
        //[RequireRequestValue("speciesId")]
        //public ActionResult New(int speciesId)
        //{
        //    PlantSeedSite item = new PlantSeedSite();
        //    item.SpeciesId = (int)speciesId;

        //    return AutoMapView<SiteNewViewModel>(View(item));
        //}

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
            IViewResponse<PlantSeedSite> response = _dataService.View(id);

            PlantSeedSite item = response.Item;

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
            IViewResponse<PlantSeedSite> response = _dataService.View(id);

            PlantSeedSite item = response.Item;

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
