using PlantDataMVC.UI.Forms;
using System;
using System.Web.Mvc;

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
    public class FormControllerBase : Controller
    {
        private readonly IFormHandlerFactory _formHandlerFactory;

        protected FormControllerBase(IFormHandlerFactory formHandlerFactory)
        {
            this._formHandlerFactory = formHandlerFactory;
        }

        /// <summary>
        /// An action to handle posts from a form, defining the view to display on successful completion.
        /// If the action is unsuccessful the form will be redisplayed.
        /// </summary>
        /// <typeparam name="TForm">The form type.</typeparam>
        /// <param name="form">The form instance.</param>
        /// <param name="success">The view to display on success.</param>
        /// <returns></returns>
        protected ActionResult Form<TForm>(TForm form, ActionResult successResult) where TForm : IForm
        {
            return Form(form, () => successResult);
        }

        protected ActionResult Form<TForm>(TForm form, ActionResult successResult, ActionResult failureResult) where TForm : IForm
        {
            return Form(form, () => successResult, () => failureResult);
        }

        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult) where TForm : IForm
        {
            return Form(form, successResult, () => Redirect(Request.UrlReferrer.AbsoluteUri));
        }

        // The generic form of the method
        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult, Func<ActionResult> failResult) where TForm : IForm
        {
            if (ModelState.IsValid)
            {
                _formHandlerFactory.Create<TForm>().Handle(form);

                return successResult();
            }

            return failResult();
        }


    }
}
