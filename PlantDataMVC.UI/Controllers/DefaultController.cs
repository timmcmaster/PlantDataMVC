using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Controllers
{
    /// <summary>
    /// An MVC controller that implements all of the basic CRUD methods (Create, Read, Update, Delete)
    /// as well as an index method.
    /// This should be the base class for most controllers in the system.
    /// The underlying data is provided through a Request/Response data service which uses the business object.
    /// The business object is mapped to the local model type and back as necessary.
    /// </summary>
    /// <typeparam name="T">The type of the business object being used.</typeparam>
    /// <typeparam name="U">The type of the local model for viewing the business object.</typeparam>
    public abstract class DefaultController : FormControllerBase
    {
        public DefaultController(IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
        {
        }

        /// <summary>
        /// Maps the Model property of the View passed in to the destination type defined in the type parameter.
        /// An Automapper configuration to map between the two types should exist.
        /// </summary>
        /// <typeparam name="TDestination">The type to convert the model to.</typeparam>
        /// <param name="viewResult">The view whose model will be changed</param>
        /// <returns></returns>
        //protected AutoMapViewResult AutoMapView<TDestination>(ViewResult viewResult)
        //{
        //    return new AutoMapViewResult(
        //        viewResult.ViewData.Model.GetType(),
        //        typeof(TDestination),
        //        viewResult);
        //}

        protected AutoMapPreProcessingViewResult AutoMapView<TDestination>(ViewResult viewResult)
        {
            if (!(viewResult is PreProcessingViewResult))
            {
                viewResult = new PreProcessingViewResult(viewResult);
            }

            Type modelType = ((PreProcessingViewResult)viewResult).GetRootViewResult().ViewData.Model.GetType();

            return new AutoMapPreProcessingViewResult(modelType, typeof(TDestination), (PreProcessingViewResult)viewResult);
        }

        //protected ListViewResult<TElement> ListView<TElement>(ViewResult viewResult, int? page, int? pageSize, string sortBy, bool? ascending)
        //{
        //    // resolve parameters
        //    int localPage = page ?? 0;
        //    int localPageSize = pageSize ?? 40;
        //    string localSortBy = sortBy ?? string.Empty;
        //    bool localAscending = ascending ?? true;


        //    return new ListViewResult<TElement>(viewResult, localPage, localPageSize, localSortBy, localAscending);
        //}

        protected ListViewPreProcessingViewResult<TElement> ListView<TElement>(ViewResult viewResult, int? page, int? pageSize, string sortBy, bool? ascending)
        {
            // resolve parameters
            int localPage = page ?? 0;
            int localPageSize = pageSize ?? 40;
            string localSortBy = sortBy ?? string.Empty;
            bool localAscending = ascending ?? true;

            if (!(viewResult is PreProcessingViewResult))
            {
                viewResult = new PreProcessingViewResult(viewResult);
            }

            return new ListViewPreProcessingViewResult<TElement>((PreProcessingViewResult)viewResult, localPage, localPageSize, localSortBy, localAscending);
        }

        // GET: /"ControllerName"/Index
        // GET: /"ControllerName"/Index?page=4&pageSize=20&sortBy=Genus&ascending=True
        public abstract ActionResult Index(int? page, int? pageSize, string sortBy, bool? ascending);

        //
        // GET: /"ControllerName"/Show/5
        public abstract ActionResult Show(int id);

        //
        // GET: /"ControllerName"/New
        public abstract ActionResult New();

        //
        // POST: /"ControllerName"/Create
        //public abstract ActionResult Create(U model);

        //
        // GET: /"ControllerName"/Edit/5
        public abstract ActionResult Edit(int id);

        //
        // POST: /"ControllerName"/Update/5
        //public abstract ActionResult Update(int id);

        //
        // GET: /"ControllerName"/Delete/5
        public abstract ActionResult Delete(int id);

        //
        // POST: /Plant/Delete/5
        //public abstract ActionResult Destroy(int id);
    }
}
