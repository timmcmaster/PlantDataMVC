using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Framework.Web;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;

namespace PlantDataMVC.UI.Controllers
{
    public class TransactionController : FormControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator, IFormHandlerFactory formHandlerFactory) : base(mediator, formHandlerFactory)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Additional action for creating a new entry for a given plant stock entry.
        /// </summary>
        /// <param name="plantStockId">The Id of the plant stock entry.</param>
        /// <returns></returns>
        //[RequireRequestValue("plantStockId")]
        public ActionResult New(int plantStockId)
        {
            var item = new JournalEntryDto {PlantStockId = plantStockId};

            // TODO: check to ensure these DTOs map to view model
            var model = Mapper.Map<JournalEntryDto, PlantStockTransactionNewViewModel>(item);
            return View(model);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int plantStockId, PlantStockTransactionCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Details","PlantStock",new {id = plantStockId});

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var query = new PlantStockTransactionEditQuery(id);
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
        public async Task<ActionResult> Update(int plantStockId, PlantStockTransactionUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Details", "PlantStock", new { id = plantStockId });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var query = new PlantStockTransactionDeleteQuery(id);
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
        public async Task<ActionResult> Destroy(int plantStockId, PlantStockTransactionDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Details", "PlantStock", new { id = plantStockId });

            return await Form(form, success);
        }
    }
}
