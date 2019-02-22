using PlantDataMVC.DTO.Dtos;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Framework.Web.Mediator;
using PlantDataMVC.UI.Controllers.Queries.Transaction;
using PlantDataMVC.UI.Models.EditModels.Transaction;
using PlantDataMVC.UI.Models.ViewModels.Transaction;
using Thinktecture.IdentityModel.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    // TODO: Use userId in posts having ValidateAntiForgeryToken (as per GenusController)

    public class TransactionController : DefaultController
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        //[RequireRequestValue("plantStockId")]
        [ResourceAuthorize("Write", "Transaction")]
        public ActionResult New(int plantStockId)
        {
            var item = new JournalEntryDto {PlantStockId = plantStockId};

            // TODO: check to ensure these DTOs map to view model
            var model = Mapper.Map<JournalEntryDto, TransactionNewViewModel>(item);
            return View(model);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int plantStockId, TransactionCreateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", "PlantStock", new { id = plantStockId });

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // GET: /"ControllerName"/Edit/5
        [ResourceAuthorize("Write", "Transaction")]
        public async Task<ActionResult> Edit(int id)
        {
            var query = new EditQuery(id);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int plantStockId, TransactionUpdateEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", "PlantStock", new { id = plantStockId });

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }

        //
        // GET: /"ControllerName"/Delete/5
        [ResourceAuthorize("Write", "Transaction")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new DeleteQuery(id);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }
            else
            {
                return View(model);
            }
        }

        //
        // POST: /"ControllerName"/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(int plantStockId, TransactionDestroyEditModel form)
        {
            var failureResult = DefaultFormFailureResult();
            var successResult = RedirectToAction("Details", "PlantStock", new { id = plantStockId });

            if (!ModelState.IsValid)
            {
                return failureResult;
            }

            var result = await _mediator.Send(form);
            return result ? successResult : failureResult;
        }
    }
}
