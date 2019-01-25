using System;
using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using Newtonsoft.Json;
using PlantDataMVC.UI.Helpers;


namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : DefaultController
    {
        private readonly ISpeciesWcfService _dataService;

        public PlantController(ISpeciesWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // TODO: Change how paging works - retrieving paged data means that paging the returned list does not work
            // as it used to

            // resolve parameters
            var localPage = page ?? 0;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var client = MyHttpClient.GetClient();
            HttpResponseMessage httpResponse = await client.GetAsync("api/Species");

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<SpeciesDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantListViewModel>>(View(model));

                return ListView<PlantListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
            }
            else
            {
                return Content("An error occurred");
            }

            /*
            IListResponse<SpeciesInListDto> response = _dataService.List();

            if (response.Status == ServiceActionStatus.Ok)
            {
                IList<SpeciesInListDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantListViewModel>>(View(list));

            return ListView<PlantListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
            }
            else
            {
                return Content("An error occurred (WCF)");
            }
            */

        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<SpeciesDto> response = _dataService.View(id);

            SpeciesDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/Show/5
        public ActionResult ShowBasic(int id)
        {
            // return view for Model
            IViewResponse<SpeciesDto> response = _dataService.View(id);

            SpeciesDto item = response.Item;

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
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<SpeciesDto> response = _dataService.View(id);

            SpeciesDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<SpeciesDto> response = _dataService.View(id);

            SpeciesDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantDeleteViewModel>(View(item));
        }

        //
        // POST: /Plant/Delete/5
        public ActionResult Destroy(PlantDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }
    }
}
