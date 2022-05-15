using Framework.Web.Core.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PlantDataMVC.UICore.Handlers
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQueryHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TQuery : IQuery<TViewModel>
        {
            IQueryHandler<TQuery, TViewModel> queryHandler;

            try
            {
                // Create handler by resolving it from context
                queryHandler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TViewModel>>();
            }
            catch (InvalidOperationException)
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