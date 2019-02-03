using Framework.Web.Forms;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using Framework.Web;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;


namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : ViewFormControllerBase
    {
        public PlantController(IViewHandlerFactory viewHandlerFactory, IFormHandlerFactory formHandlerFactory) : base(viewHandlerFactory,formHandlerFactory)
        {
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

            var query = new IndexQuery(localPage, localPageSize);
            var handler = _viewHandlerFactory.Create<ListViewModelStatic<PlantListViewModel>, IndexQuery>();
            var model = await handler.HandleAsync(query);

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
            var handler = _viewHandlerFactory.Create<PlantShowViewModel, ShowQuery>();
            var model = await handler.HandleAsync(new ShowQuery(id));

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
        // Display prior to POST via Create 
        public ActionResult New()
        {
            var item = new PlantNewViewModel();
            return View(item);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // Display prior to POST via Update 
        public async Task<ActionResult> Edit(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantEditViewModel, ShowQuery>();
            var model = await handler.HandleAsync(new ShowQuery(id));

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
        public async Task<ActionResult> Update(PlantUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // Display prior to DELETE via Destroy method 
        public async Task<ActionResult> Delete(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantDeleteViewModel, ShowQuery>();
            var model = await handler.HandleAsync(new ShowQuery(id));

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
        // DELETE: /Plant/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
