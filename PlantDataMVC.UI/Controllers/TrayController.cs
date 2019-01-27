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
    public class TrayController : DefaultController
    {
        private readonly ISeedTrayWcfService _dataService;

        public TrayController(ISeedTrayWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<SeedTrayDto> response = _dataService.List();

            IList<SeedTrayDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<TrayListViewModel>>(View(list));

            return ListView<TrayListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async override Task<ActionResult> Show(int id)
        {
            // return view for Model
            IViewResponse<SeedTrayDto> response = _dataService.View(id);

            SeedTrayDto item = response.Item;

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
            var item = new SeedTrayDto {SeedBatchId = seedBatchId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public async Task<ActionResult> Create(TrayCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async override Task<ActionResult> Edit(int id)
        {
            // return view for Model
            IViewResponse<SeedTrayDto> response = _dataService.View(id);

            SeedTrayDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(TrayUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async override Task<ActionResult> Delete(int id)
        {
            // return view for Model
            IViewResponse<SeedTrayDto> response = _dataService.View(id);

            SeedTrayDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<TrayDeleteViewModel>(View(item));
        }

        //
        // POST: /SeedTrayDTO/Delete/5
        public async Task<ActionResult> Destroy(TrayDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
