﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Controllers.Queries.Transaction;
using PlantDataMVC.Web.Helpers;
using PlantDataMVC.Web.Models.EditModels.Transaction;
using PlantDataMVC.Web.Models.ViewModels.Transaction;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Controllers
{
    // TODO: Use userId in posts having ValidateAntiForgeryToken (as per GenusController)

    public class TransactionController : DefaultController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TransactionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: /"ControllerName"/StockSummary
        // GET: /"ControllerName"/StockSummary?page=4&pageSize=20&sortBy=Genus&ascending=True
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public async Task<ActionResult> StockSummary(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? "SpeciesId";
            var localAscending = ascending ?? true;

            var query = new StockSummaryQuery(localPage, localPageSize, localSortBy, localAscending);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }


        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        //[RequireRequestValue("plantStockId")]
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public ActionResult New(int speciesId, int productTypeId)
        {
            var item = new JournalEntryDataModel { SpeciesId = speciesId, ProductTypeId = productTypeId };
            var model = _mapper.Map<JournalEntryDataModel, TransactionNewViewModel>(item);
            return View(model);
        }

        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransactionCreateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            //var successResult = RedirectToAction("Details", PlantDataMvcAppControllers.PlantStock, new { id = plantStockId });
            var successResult = RedirectToAction("About", PlantDataMvcAppControllers.Home); // TODO: fix redirect

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        // GET: /"ControllerName"/Edit/5
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Edit(int id)
        {
            var query = new EditQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int plantStockId, TransactionUpdateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", @PlantDataMvcAppControllers.PlantStock, new { id = plantStockId });

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        // GET: /"ControllerName"/Delete/5
        //[Authorize(Policy = AuthorizationPolicies.RequireWriteUserRole)]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new DeleteQuery(id);
            var model = await _mediator.Send(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(int plantStockId, TransactionDestroyEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", @PlantDataMvcAppControllers.PlantStock, new { id = plantStockId });

            if (!ModelState.IsValid)
            {
                // TODO: Display any model validation errors
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }
    }
}

