using Autofac;
using Framework.Web.Views;

namespace PlantDataMVC.UI.Handlers
{
    /// <summary>
    ///     TODO: I don't think this class is actually necessary.
    ///     I'm pretty sure I can do the same with Autofac directly, just haven't yet worked out how.
    /// </summary>
    public class AutofacViewHandlerFactory : IViewHandlerFactory
    {
        private readonly IComponentContext _c;

        public AutofacViewHandlerFactory(IComponentContext c)
        {
            _c = c;
        }

        public IViewHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TViewModel : IViewModel
                                                                             where TQuery : IViewQuery
        {
            // Create handler by resolving it from context
            // Data service parameter for formHandler will also be resolved from IoC (I think?)
            var viewHandler = _c.Resolve<IViewHandler<TQuery, TViewModel>>();
            return viewHandler;
        }
    }
}