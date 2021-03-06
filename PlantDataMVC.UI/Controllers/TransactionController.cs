﻿using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.UI.Controllers
{
    public class TransactionController : DefaultController
    {
        private IPlantStockTransactionDataService _dataService;

        public TransactionController(IPlantStockTransactionDataService dataService, IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
            // use passed in service
            _dataService = dataService;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public override ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            IListResponse<PlantStockTransaction> response = _dataService.List();

            IList<PlantStockTransaction> list = response.Items;

            AutoMapPreProcessingViewResult autoMapResult = AutoMapView<List<PlantStockTransactionListViewModel>>(View(list));

            return ListView<PlantStockTransactionListViewModel>(autoMapResult, page, pageSize, sortBy, ascending);
        }

        //
        // GET: /"ControllerName"/Show/5
        public override ActionResult Show(int id)
        {
            // return view for Model
            IViewResponse<PlantStockTransaction> response = _dataService.View(id);

            PlantStockTransaction item = response.Item;

            return AutoMapView<PlantStockTransactionShowViewModel>(View(item));
        }

        //
        // GET: /"ControllerName"/New
        public override ActionResult New()
        {
            PlantStockTransaction item = new PlantStockTransaction();

            return AutoMapView<PlantStockTransactionNewViewModel>(View(item));
        }

        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockEntryId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        [RequireRequestValue("plantStockEntryId")]
        public ActionResult New(int plantStockEntryId)
        {
            PlantStockTransaction item = new PlantStockTransaction();
            item.PlantStockEntryId = plantStockEntryId;

            return AutoMapView<PlantStockTransactionNewViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Create
        public ActionResult Create(PlantStockTransactionCreateEditModel form)
        {
            var success = this.RedirectToAction("Index");

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public override ActionResult Edit(int id)
        {
            // return view for Model
            IViewResponse<PlantStockTransaction> response = _dataService.View(id);

            PlantStockTransaction item = response.Item;

            return AutoMapView<PlantStockTransactionEditViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Update/5
        public ActionResult Update(PlantStockTransactionUpdateEditModel form)
        {
            var success = this.RedirectToAction("Show", new { id = form.Id });

            return Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public override ActionResult Delete(int id)
        {
            // return view for Model
            IViewResponse<PlantStockTransaction> response = _dataService.View(id);

            PlantStockTransaction item = response.Item;

            return AutoMapView<PlantStockTransactionDeleteViewModel>(View(item));
        }

        //
        // POST: /"ControllerName"/Delete/5
        public ActionResult Destroy(PlantStockTransactionDestroyEditModel form)
        {
            var success = this.RedirectToAction("Index");

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
        //    ViewResponse<PlantStockTransaction> response = DataService.View(new ViewRequest<PlantStockTransaction>(id));

        //    PlantStockTransactionModel pstModel = AutoMapper.Mapper.Map<PlantStockTransaction, PlantStockTransactionModel>(response.Item);

        //    EditTransactionViewModel viewModel = new EditTransactionViewModel() { Transaction = pstModel, TransactionTypes = transactionTypeList };

        //    return View(viewModel);
        //}
    }
}
