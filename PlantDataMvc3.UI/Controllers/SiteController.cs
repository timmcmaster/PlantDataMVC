using System.Collections.Generic;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMvc3.UI.ServiceLayerAccess;
using PlantDataMvc3.UI.Helpers;
using PlantDataMvc3.UI.Helpers.ViewResults;
using PlantDataMvc3.UI.Models;

namespace PlantDataMvc3.UI.Controllers
{
    public class SiteController : DefaultController
    {
        private IBasicDataService<PlantSeedSite> _dataService;

        public SiteController(): this(null)
        {
        }

        public SiteController(IBasicDataService<PlantSeedSite> dataService)
        {
            // use passed in service or default instance service
            _dataService = dataService ?? ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantSeedSite>();
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            ListResponse<PlantSeedSite> response = _dataService.List(new ListRequest<PlantSeedSite>());

            IList<PlantSeedSite> list = response.Items;

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<IList<SiteListViewModel>>(View(list));

            return ListView<SiteListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            ViewResponse<PlantSeedSite> response = _dataService.View(new ViewRequest<PlantSeedSite>(id));

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
            ViewResponse<PlantSeedSite> response = _dataService.View(new ViewRequest<PlantSeedSite>(id));

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
            ViewResponse<PlantSeedSite> response = _dataService.View(new ViewRequest<PlantSeedSite>(id));

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
