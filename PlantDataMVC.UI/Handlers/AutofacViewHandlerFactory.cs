using System;
using Autofac;
using Autofac.Core.Registration;
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

        public IViewHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TQuery : IViewQuery<TViewModel>
        {
            IViewHandler<TQuery, TViewModel> viewHandler;

            try
            {
                // Create handler by resolving it from context
                viewHandler = _c.Resolve<IViewHandler<TQuery, TViewModel>>();
            }
            catch (ComponentNotRegisteredException)
            {
                throw new InvalidOperationException(
                    $"Handler was not found for request of type {typeof(IViewHandler<TQuery, TViewModel>)}. Ensure it is registered with the container.");
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    $"Error constructing form handler for request of type {typeof(IViewHandler<TQuery, TViewModel>)}. Ensure it and any dependencies are registered with the container.");
            }

            return viewHandler;

        }
    }
}