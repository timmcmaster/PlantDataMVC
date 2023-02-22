using Framework.Web.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace PlantDataMVC.Web.Handlers
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
                // TODO: Effectively servicelocator pattern - can I do it better?
                var matchingServices = _serviceProvider.GetServices(typeof(IQueryHandler<TQuery, TViewModel>));

                // Create handler by resolving it from context
                queryHandler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TViewModel>>();

                Log.Information($"Resolved service {typeof(IQueryHandler<TQuery, TViewModel>)} with implementation {queryHandler.GetType()}");
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