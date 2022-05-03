using System;
using Autofac;
using Autofac.Core.Registration;
using Framework.Web.Core.Forms;

namespace PlantDataMVC.UICore.Handlers
{
    // TODO: Work out how to do this with MS Native DI
    /// <summary>
    /// TODO: I don't think this class is actually necessary.
    /// I'm pretty sure I can do the same with Autofac directly, just haven't yet worked out how.
    /// </summary>
    public class AutofacFormHandlerFactory : IFormHandlerFactory
    {
        private readonly IComponentContext _c;

        public AutofacFormHandlerFactory(IComponentContext c)
        {
            _c = c;
        }

        public IFormHandler<TForm, TResult> Create<TForm, TResult>() where TForm : IForm<TResult>
        {
            IFormHandler<TForm, TResult> formHandler;

            try
            {
                // Create handler by resolving it from context
                // Data service parameter for formHandler will also be resolved from IoC (I think?)
                formHandler = _c.Resolve<IFormHandler<TForm, TResult>>();
            }
            catch (ComponentNotRegisteredException)
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