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
    public class GenusController : DefaultController
    {
        private readonly IGenusWcfService _dataService;

        public GenusController(IGenusWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 0;
            var localPageSize = pageSize ?? 40;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            IListResponse<GenusInListDto> response = _dataService.List();

            IList<GenusInListDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<GenusListViewModel>>(View(list));

            return ListView<GenusListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<GenusDto> response = _dataService.View(id);

            GenusDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<GenusShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/Show/5
        public ActionResult ShowBasic(int id)
        {
            // return view for Model
            IViewResponse<GenusDto> response = _dataService.View(id);

            GenusDto item = response.Item;

            return View(item);
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new GenusDto();

            return AutoMapView<GenusNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(GenusCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<GenusDto> response = _dataService.View(id);

            GenusDto item = response.Item;

            return AutoMapView<GenusEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(GenusUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<GenusDto> response = _dataService.View(id);

            GenusDto item = response.Item;

            return AutoMapView<GenusDeleteViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Delete/5
        public ActionResult Destroy(GenusDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
