using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.UI.Models.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Framework.Web;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;

namespace PlantDataMVC.UI.Controllers
{
    public class SeedController : ViewFormControllerBase
    {
        public SeedController(IViewHandlerFactory viewHandlerFactory, IFormHandlerFactory formHandlerFactory) : base(viewHandlerFactory, formHandlerFactory)
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

            var query = new PlantSeedIndexQuery(localPage, localPageSize);
            var handler = _viewHandlerFactory.Create<PlantSeedIndexQuery, ListViewModelStatic<PlantSeedListViewModel>>();
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
            var handler = _viewHandlerFactory.Create<PlantSeedShowQuery, PlantSeedShowViewModel>();
            var model = await handler.HandleAsync(new PlantSeedShowQuery(id));

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
            var item = new PlantSeedNewViewModel();
            return View(item);
        }

        /// <summary>
        /// Additional action for creating a new entry for a given species.
        /// </summary>
        /// <param name="speciesId">The Id of the species.</param>
        /// <returns></returns>
        [RequireRequestValue("speciesId")]
        public ActionResult New(int speciesId)
        {
            var item = new SeedBatchDto { SpeciesId = speciesId };

            // TODO: check to ensure these DTOs map to view model
            var model = Mapper.Map<SeedBatchDto, PlantSeedNewViewModel>(item);
            return View(model);
        }

        //
        // POST: /"ControllerName"/Create
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlantSeedCreateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantSeedEditQuery, PlantSeedEditViewModel>();
            var model = await handler.HandleAsync(new PlantSeedEditQuery(id));

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
        public async Task<ActionResult> Update(PlantSeedUpdateEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Show", new { id = form.Id });

            return await Form(form, success);
        }

        //
        // GET: /"ControllerName"/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var handler = _viewHandlerFactory.Create<PlantSeedDeleteQuery, PlantSeedDeleteViewModel>();
            var model = await handler.HandleAsync(new PlantSeedDeleteQuery(id));

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
        public async Task<ActionResult> Destroy(PlantSeedDestroyEditModel form)
        {
            RedirectToRouteResult success = RedirectToAction("Index");

            return await Form(form, success);
        }
    }
}
