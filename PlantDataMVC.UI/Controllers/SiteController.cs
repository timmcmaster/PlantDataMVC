using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
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
    public class SiteController : DefaultController
    {
        private readonly ISiteWcfService _dataService;

        public SiteController(ISiteWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<SiteDto> response = _dataService.List();

            IList<SiteDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<SiteListViewModel>>(View(list));

            return ListView<SiteListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async override Task<ActionResult> Show(int id)
        {
            // return view for Model
            IViewResponse<SiteDto> response = _dataService.View(id);

            SiteDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new SiteDto();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public async Task<ActionResult> Create(SiteCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async override Task<ActionResult> Edit(int id)
        {
            // return view for Model
            IViewResponse<SiteDto> response = _dataService.View(id);

            SiteDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public async Task<ActionResult> Update(SiteUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async override Task<ActionResult> Delete(int id)
        {
            // return view for Model
            IViewResponse<SiteDto> response = _dataService.View(id);

            SiteDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<SiteDeleteViewModel>(View(item));
        }

        //
        // POST: /Seed/Delete/5
        public async Task<ActionResult> Destroy(SiteDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
