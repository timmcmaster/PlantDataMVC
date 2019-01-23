using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Web.Mvc;
using Interfaces.WcfService.Responses;

namespace PlantDataMVC.UI.Controllers
{
    public class SeedController : DefaultController
    {
        private readonly ISeedBatchWcfService _dataService;

        public SeedController(ISeedBatchWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service or default instance service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<SeedBatchDto> response = _dataService.List();

            IList<SeedBatchDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantSeedListViewModel>>(View(list));

            return ListView<PlantSeedListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<SeedBatchDto> response = _dataService.View(id);

            SeedBatchDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new SeedBatchDto();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedNewViewModel>(View(item));
        }

        /// <summary>
        /// Additional action for creating a new entry for a given species.
        /// </summary>
        /// <param name="speciesId">The Id of the species.</param>
        /// <returns></returns>
        [RequireRequestValue("speciesId")]
        public ActionResult New(int speciesId)
        {
            var item = new SeedBatchDto {SpeciesId = speciesId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(PlantSeedCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<SeedBatchDto> response = _dataService.View(id);

            SeedBatchDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantSeedUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<SeedBatchDto> response = _dataService.View(id);

            SeedBatchDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedDeleteViewModel>(View(item));
        }

        //
        // POST: /Seed/Delete/5
        public ActionResult Destroy(PlantSeedDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
