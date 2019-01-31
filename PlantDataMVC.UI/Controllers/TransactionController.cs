﻿using Framework.Web.Forms;
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
        public override async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            IListResponse<JournalEntryDto> response = _dataService.List();

            IList<JournalEntryDto> list = response.Items;

            // TODO: check to ensure these DTOs map to view model
            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockTransactionListViewModel>>(View(list));

            return ListView<PlantStockTransactionListViewModel>(autoMapResult, localPage, localPageSize, localSortBy, localAscending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async override Task<ActionResult> Show(int id)
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
            var item = new PlantStockTransactionNewViewModel();
            return View(item);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantStockTransactionCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async override Task<ActionResult> Edit(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PlantStockTransactionUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async override Task<ActionResult> Delete(int id)
        {
            // return view for Model
            IViewResponse<JournalEntryDto> response = _dataService.View(id);

            JournalEntryDto item = response.Item;

            // TODO: check to ensure these DTOs map to view model
            return AutoMapView<PlantStockTransactionDeleteViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantStockTransactionDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
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
