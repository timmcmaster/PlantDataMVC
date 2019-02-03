using Framework.Web.Forms;
using Framework.Web.Views;

namespace Framework.Web
{
    public class ViewFormControllerBase : FormControllerBase
    {
        protected IViewHandlerFactory _viewHandlerFactory;

        protected ViewFormControllerBase(IViewHandlerFactory viewHandlerFactory, IFormHandlerFactory formHandlerFactory): base(formHandlerFactory)
        {
            _viewHandlerFactory = viewHandlerFactory;
        }

    }
}