using Autofac;
using Framework.Web.Forms;

namespace PlantDataMVC.UI.Forms
{
    /// <summary>
    /// TODO: I don't think this class is actually necessary.
    /// I'm pretty sure I can do the same with Autofac directly, just haven't yet worked out how.
    /// </summary>
    public class AutofacFormHandlerFactory: IFormHandlerFactory
    {
        private readonly IComponentContext _c;

        public AutofacFormHandlerFactory(IComponentContext c)
        {
            _c = c;
        }

        public IFormHandler<TForm> Create<TForm>() where TForm : IForm
        {
            // Create handler by resolving it from context
            // Data service parameter for formhandler will also be resolved from IoC (I think?)
            IFormHandler<TForm> formHandler = _c.Resolve<IFormHandler<TForm>>();
            return formHandler;
        }
    }
}