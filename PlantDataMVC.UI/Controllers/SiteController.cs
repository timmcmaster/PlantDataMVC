using Framework.Web.Forms;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using Framework.Web;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;

namespace PlantDataMVC.UI.Controllers
{
    public class SiteController : FormControllerBase
    {
        private readonly IMediator _mediator;

        public SiteController(IMediator mediator, IFormHandlerFactory formHandlerFactory) : base(mediator, formHandlerFactory)
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

            var query = new SiteIndexQuery(localPage, localPageSize);
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
        // GET: /"ControllerName"/Show/5
        public async Task<ActionResult> Show(int id)
        {
            var query = new SiteShowQuery(id);
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
        // GET: /"ControllerName"/New
        public ActionResult New()
        {
            var item = new SiteNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SiteCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var query = new SiteEditQuery(id);
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
        public async Task<ActionResult> Update(SiteUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var query = new SiteDeleteQuery(id);
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
        // POST: /Seed/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(SiteDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
