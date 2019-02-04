using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Framework.Web;
using Framework.Web.Forms;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers
{
    public class TrayController : FormControllerBase
    {
        private readonly IMediator _mediator;

        public TrayController(IMediator mediator, IFormHandlerFactory formHandlerFactory) : base(mediator, formHandlerFactory)
        {
            _mediator = mediator;
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public async Task<ActionResult> Index(int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            var localPage = page ?? 1;
            var localPageSize = pageSize ?? 20;
            var localSortBy = sortBy ?? string.Empty;
            var localAscending = ascending ?? true;

            var query = new TrayIndexQuery(localPage, localPageSize);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // GET: /"ControllerName"/Show/5
        public async Task<ActionResult> Show(int id)
        {
            var query = new TrayShowQuery(id);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // GET: /"ControllerName"/New
        public ActionResult New()
        {
            var item = new TrayNewViewModel();
            return View(item);
        }

        /// <summary>
        ///     Additional action for creating a new seed tray entry for a given seed batch.
        /// </summary>
        /// <param name="seedBatchId">The Id of the seed batch.</param>
        /// <returns></returns>
        [RequireRequestValue("seedBatchId")]
        public ActionResult New(int seedBatchId)
        {
            var item = new SeedTrayDto { SeedBatchId = seedBatchId };

            // TODO: check to ensure these DTOs map to view model
            var model = Mapper.Map<SeedTrayDto, TrayNewViewModel>(item);
            return View(model);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TrayCreateEditModel form)
        {
            var success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var query = new TrayEditQuery(id);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TrayUpdateEditModel form)
        {
            var success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var query = new TrayDeleteQuery(id);
            var model = await _mediator.Request(query);

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // POST: /SeedTrayDTO/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(TrayDestroyEditModel form)
        {
            var success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}