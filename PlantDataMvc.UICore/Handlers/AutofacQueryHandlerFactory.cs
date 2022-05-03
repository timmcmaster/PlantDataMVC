using System;
using Autofac;
using Autofac.Core.Registration;
using Framework.Web.Core.Views;

namespace PlantDataMVC.UICore.Handlers
{
    // TODO: Work out how to do this with MS Native DI
    /// <summary>
    ///     TODO: I don't think this class is actually necessary.
    ///     I'm pretty sure I can do the same with Autofac directly, just haven't yet worked out how.
    /// </summary>
    public class AutofacQueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IComponentContext _c;

        public AutofacQueryHandlerFactory(IComponentContext c)
        {
            _c = c;
        }

        public IQueryHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TQuery : IQuery<TViewModel>
        {
            IQueryHandler<TQuery, TViewModel> queryHandler;

            try
            {
                // Create handler by resolving it from context
                queryHandler = _c.Resolve<IQueryHandler<TQuery, TViewModel>>();
            }
            catch (ComponentNotRegisteredException)
            {
                throw new InvalidOperationException(
                    $"Handler was not found for request of type {typeof(IQueryHandler<TQuery, TViewModel>)}. Ensure it is registered with the container.");
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    $"Error constructing form handler for request of type {typeof(IQueryHandler<TQuery, TViewModel>)}. Ensure it and any dependencies are registered with the container.");
            }

            return queryHandler;

        }
    }
}