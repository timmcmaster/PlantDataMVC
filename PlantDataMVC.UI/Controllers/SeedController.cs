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
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 40;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            IListResponse<SeedBatchDto> response = _dataService.List();

            IList<SeedBatchDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantSeedListViewModel>>(View(list));

            return ListView<PlantSeedListViewModel>(autoMapResult, localPage, localPageSize, localSortBy, localAscending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async override Task<ActionResult> Show(int id)
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
            var item = new PlantSeedNewViewModel();
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
            var item = new SeedBatchDto {SpeciesId = speciesId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public async Task<ActionResult> Create(PlantSeedCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async override Task<ActionResult> Edit(int id)
        {
            // return view for Model
            IViewResponse<SeedBatchDto> response = _dataService.View(id);

            SeedBatchDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(PlantSeedUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async override Task<ActionResult> Delete(int id)
        {
            // return view for Model
            IViewResponse<SeedBatchDto> response = _dataService.View(id);

            SeedBatchDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantSeedDeleteViewModel>(View(item));
        }

        //
        // POST: /Seed/Delete/5
        public async Task<ActionResult> Destroy(PlantSeedDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
