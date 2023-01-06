using Framework.Web.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using Serilog;

namespace PlantDataMVC.Web.Handlers
{
    public class FormHandlerFactory : IFormHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FormHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IFormHandler<TForm, TResult> Create<TForm, TResult>() where TForm : IForm<TResult>
        {
            IFormHandler<TForm, TResult> formHandler;

            try
            {
                var matchingServices = _serviceProvider.GetServices(typeof(IFormHandler<TForm, TResult>));

                // Create handler by resolving it from context
                // Data service parameter for formHandler will also be resolved from IoC (I think?)
                formHandler = _serviceProvider.GetRequiredService<IFormHandler<TForm, TResult>>();

                Log.Information($"Resolved service {typeof(IFormHandler<TForm, TResult>)} with implementation {formHandler.GetType()}");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(
                    $"Handler was not found for request of type {typeof(IFormHandler<TForm, TResult>)}. Ensure it is registered with the container.");
            }
            catch (Exception)
            {
                throw new InvalidOperationException(
                    $"Error constructing form handler for request of type {typeof(IFormHandler<TForm, TResult>)}. Ensure it and any dependencies are registered with the container.");
            }

            return formHandler;
        }
    }
}