using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantDataMvc3.UI.Helpers
{
    /// <summary>
    /// Defines an action result which encompasses form handling, 
    /// given the form, and actions to perform on success or failure.
    /// </summary>
    /// <typeparam name="T">The type of the form</typeparam>
    public class FormActionResult<TForm> : ActionResult
    {
        public ViewResult Failure { get; private set; }
        public ActionResult Success { get; private set; }
        public TForm Form { get; private set; }

        public FormActionResult(TForm form, ActionResult success, ViewResult failure)
        {
            Form = form;
            Success = success;
            Failure = failure;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                Failure.ExecuteResult(context);

                return;
            }

            IFormHandler<TForm> handler = FormHandlerFactory.GetFormHandler<TForm>();

            handler.Handle(Form);

            Success.ExecuteResult(context);
        }
    }
}