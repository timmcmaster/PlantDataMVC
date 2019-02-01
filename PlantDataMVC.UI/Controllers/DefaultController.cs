using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using System;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// An MVC controller that implements all of the basic CRUD methods (Create, Read, Update, Delete)
    /// as well as an index method.
    /// This should be the base class for most controllers in the system.
    /// The underlying data is provided through a Request/Response data service which uses DTOs.
    /// </summary>
    public abstract class DefaultController : FormControllerBase
    {
        protected DefaultController(IFormHandlerFactory formHandlerFactory) : base(formHandlerFactory)
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

        protected ListViewPreProcessingViewResult<TElement> ListView<TElement>(ViewResult viewResult, int page, int pageSize, string sortBy, bool ascending)
        {
            if (!(viewResult is PreProcessingViewResult))
            {
                viewResult = new PreProcessingViewResult(viewResult);
            }

            return new ListViewPreProcessingViewResult<TElement>((PreProcessingViewResult)viewResult, page, pageSize, sortBy, ascending);
        }

        protected ApiListViewPreProcessingViewResult<TElement> ListView<TElement>(ViewResult viewResult, ApiPagingInfo pagingInfo, string sortBy, bool ascending)
        {
            if (!(viewResult is PreProcessingViewResult))
            {
                viewResult = new PreProcessingViewResult(viewResult);
            }

            return new ApiListViewPreProcessingViewResult<TElement>((PreProcessingViewResult) viewResult, pagingInfo,
                sortBy, ascending);
        }
    }
}
