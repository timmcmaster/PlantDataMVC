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
    public class TransactionController : DefaultController
    {
        private readonly IJournalEntryWcfService _dataService;

        public TransactionController(IJournalEntryWcfService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<JournalEntryDto> response = _dataService.List();

            IList<JournalEntryDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockTransactionListViewModel>>(View(list));

            return ListView<PlantStockTransactionListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            var item = new JournalEntryDto();

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionNewViewModel>(View(item));
        }

        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        [RequireRequestValue("plantStockEntryId")]
        public ActionResult New(int plantStockId)
        {
            var item = new JournalEntryDto {PlantStockId = plantStockId};

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(PlantStockTransactionCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantStockTransactionUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionDeleteViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Delete/5
        public ActionResult Destroy(PlantStockTransactionDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return Form(form, success);
        }

        //public override ActionResult Edit(int id)
        //{
        //    // Get service for transaction types
        //    IGenericDataService<PlantStockTransactionType> transactionTypeService = ServiceFactoryManager.Instance().GetServiceFactory().GetTransactionTypeService();

        //    // Get list of transaction types
        //    ListResponse<PlantStockTransactionType> listResponse = transactionTypeService.List(new ListRequest<PlantStockTransactionType>());

        //    List<PlantStockTransactionTypeModel> transactionTypeList = AutoMapper.Mapper.Map<List<PlantStockTransactionType>, List<PlantStockTransactionTypeModel>>(listResponse.Items);

        //    // Get transaction item
        //    ViewResponse<JournalEntryDTO> response = DataService.View(new ViewRequest<JournalEntryDTO>(id));

        //    PlantStockTransactionModel pstModel = AutoMapper.Mapper.Map<JournalEntryDTO, PlantStockTransactionModel>(response.Item);

        //    EditTransactionViewModel viewModel = new EditTransactionViewModel() { Transaction = pstModel, TransactionTypes = transactionTypeList };

        //    return View(viewModel);
        //}
    }
}
