using Autofac;
using Framework.Web.Forms;

namespace PlantDataMVC.UI.Handlers
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

        public IFormHandler<TForm,TResult> Create<TForm,TResult>() where TForm : IForm<TResult>
        {
            // Create handler by resolving it from context
            // Data service parameter for formHandler will also be resolved from IoC (I think?)
            var formHandler = _c.Resolve<IFormHandler<TForm,TResult>>();
            return formHandler;
        }
    }
}