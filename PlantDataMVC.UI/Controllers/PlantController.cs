using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : DefaultController
    {
        //private IDataServiceBase<Plant> _dataService;
        private IPlantDataService _dataService;

        //public PlantController(IDataServiceBase<Plant> dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        public PlantController(IPlantDataService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
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

            IListResponse<Plant> response = _dataService.List(new ListRequest<Plant>());

            IList<Plant> list = response.Items;

            //List<IModelConverter> converters = new List<IModelConverter>();

            //converters.Add(new AutoMapModelConverter(list.GetType(), typeof(IList<PlantListViewModel>)));
            //converters.Add(new ListViewModelConverter<PlantListViewModel>(localPage, localPageSize, localSortBy, localAscending));

            //return new ModelConverterSequenceViewResult(converters.ToArray(), View(list));

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantListViewModel>>(View(list));

            return ListView<PlantListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<Plant> response = _dataService.View(new ViewRequest<Plant>(id));

            Plant item = response.Item;

            return AutoMapView<PlantShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/Show/5
        public ActionResult ShowBasic(int id)
        {
            // return view for Model
            IViewResponse<Plant> response = _dataService.View(new ViewRequest<Plant>(id));

            Plant item = response.Item;

            return View(item);
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            //Plant item = new Plant(0,"test","test","test", true, 0, new PlantSeed[]{}, new PlantStockEntry[]{});
            Plant item = new Plant();

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
            IViewResponse<Plant> response = _dataService.View(new ViewRequest<Plant>(id));

            Plant item = response.Item;

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
            IViewResponse<Plant> response = _dataService.View(new ViewRequest<Plant>(id));

            Plant item = response.Item;

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
