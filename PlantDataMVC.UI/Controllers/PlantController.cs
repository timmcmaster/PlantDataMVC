using System.Threading.Tasks;
using System.Web.Mvc;
using Framework.Web;
using Framework.Web.Forms;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Controllers
{
    public class PlantController : ViewFormControllerBase
    {
        public PlantController(IViewHandlerFactory viewHandlerFactory, IFormHandlerFactory formHandlerFactory) : base(
            viewHandlerFactory, formHandlerFactory)
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

            var query = new PlantIndexQuery(localPage, localPageSize);
            var handler = _viewHandlerFactory.Create<PlantIndexQuery, ListViewModelStatic<PlantListViewModel>>();
            var model = await handler.HandleAsync(query);

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
            var handler = _viewHandlerFactory.Create<PlantShowQuery, PlantShowViewModel>();
            var model = await handler.HandleAsync(new PlantShowQuery(id));

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
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
            var success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // Display prior to POST via Update 
        public async Task<ActionResult> Edit(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantEditQuery, PlantEditViewModel>();
            var model = await handler.HandleAsync(new PlantEditQuery(id));

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // POST: /"ControllerName"/Update/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(PlantUpdateEditModel form)
        {
            var success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // Display prior to DELETE via Destroy method 
        public async Task<ActionResult> Delete(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantDeleteQuery, PlantDeleteViewModel>();
            var model = await handler.HandleAsync(new PlantDeleteQuery(id));

            if (model == null)
            {
                return Content("An error occurred");
            }

            return View(model);
        }

        //
        // DELETE: /Plant/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(PlantDestroyEditModel form)
        {
            var success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}