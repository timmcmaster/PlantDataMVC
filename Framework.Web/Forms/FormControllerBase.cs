using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Framework.Web.Forms
{
    /// <inheritdoc />
    /// <summary>
    ///     An MVC controller that implements all of the basic CRUD methods (Create, Read, Update, Delete)
    ///     as well as an index method.
    ///     This should be the base class for most controllers in the system.
    ///     The underlying data is provided through a Request/Response data service which uses the business object.
    ///     The business object is mapped to the local model type and back as necessary.
    /// </summary>
    /// <seealso cref="T:System.Web.Mvc.Controller" />
    public class FormControllerBase : Controller
    {
        private readonly IFormHandlerFactory _formHandlerFactory;

        protected FormControllerBase(IFormHandlerFactory formHandlerFactory)
        {
            _formHandlerFactory = formHandlerFactory;
        }

        /// <summary>
        ///     An action to handle posts from a form, defining the view to display on successful completion.
        ///     If the action is unsuccessful the form will be redisplayed.
        /// </summary>
        /// <typeparam name="TForm">The form type.</typeparam>
        /// <param name="form">The form instance.</param>
        /// <param name="successResult">The view to display on success.</param>
        /// <returns></returns>
        protected async Task<ActionResult> Form<TForm>(TForm form, ActionResult successResult) where TForm : IForm
        {
            return await Form(form, () => successResult);
        }

        protected async Task<ActionResult> Form<TForm>(TForm form, ActionResult successResult,
                                                       ActionResult failureResult) where TForm : IForm
        {
            return await Form(form, () => successResult, () => failureResult);
        }

        protected async Task<ActionResult> Form<TForm>(TForm form, Func<ActionResult> successResult) where TForm : IForm
        {
            return await Form(form, successResult, () => Redirect(Request.UrlReferrer.AbsoluteUri));
        }

        // The generic form of the method
        protected async Task<ActionResult> Form<TForm>(TForm form, Func<ActionResult> successResult,
                                                       Func<ActionResult> failureResult) where TForm : IForm
        {
            if (!ModelState.IsValid)
            {
                return failureResult();
            }

            var response = await _formHandlerFactory.Create<TForm>().HandleAsync(form);

            // TODO: May need to differentiate submit failure from return failure?
            return response ? successResult() : failureResult();
        }
    }
}