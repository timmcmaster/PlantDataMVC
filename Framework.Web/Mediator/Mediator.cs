using System;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Framework.Web.Mediator;
using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IViewHandlerFactory _viewHandlerFactory;
        private readonly IFormHandlerFactory _formHandlerFactory;

        public Mediator(IViewHandlerFactory viewHandlerFactory, IFormHandlerFactory formHandlerFactory)
        {
            _viewHandlerFactory = viewHandlerFactory;
            _formHandlerFactory = formHandlerFactory;
        }

        public async Task<TViewModel> Request<TViewModel>(IViewQuery<TViewModel> query)
        {
            // resolve the handler for this query type and viewmodel type
            // the actual definitions are not as IViewQuery<TViewModel> but as a type that implements that (e.g. GenusIndexQuery)
            var queryType = query.GetType();

            var handler =
                (ViewHandlerWrapper<TViewModel>) Activator.CreateInstance(
                    typeof(ViewHandlerWrapperImpl<,>).MakeGenericType(queryType, typeof(TViewModel)));


            // call the handler to handle the request
            var viewModel = await handler.HandleAsync(query, _viewHandlerFactory);

            // return the model type
            return viewModel;
        }

        public async Task<TResult> Send<TResult>(IForm<TResult> form)
        {
            // the actual definitions are not as IForm<TResult> but as a type that implements that (e.g. GenusCreateEditModel)
            var formType = form.GetType();

            var handler =
                (FormHandlerWrapper<TResult>)Activator.CreateInstance(
                    typeof(FormHandlerWrapperImpl<,>).MakeGenericType(formType, typeof(TResult)));


            // call the handler to handle the request
            var result = await handler.HandleAsync(form, _formHandlerFactory);

            // return the model type
            return result;
        }
    }

    internal abstract class ViewHandlerWrapper<TViewModel>
    { 
        public abstract Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query,
                                                     IViewHandlerFactory viewHandlerFactory);
    }

    internal class ViewHandlerWrapperImpl<TQuery, TViewModel> : ViewHandlerWrapper<TViewModel>
        where TQuery : IViewQuery<TViewModel> 
    {
        public override async Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query,
                                                           IViewHandlerFactory viewHandlerFactory)
        {
            var handler = viewHandlerFactory.Create<TQuery, TViewModel>();

            // call the handler to handle the request
            var viewModel = await handler.HandleAsync((TQuery) query);

            // return the model type
            return viewModel;
        }
    }

    internal abstract class FormHandlerWrapper<TResult>
    {
        public abstract Task<TResult> HandleAsync(IForm<TResult> form,
                                                     IFormHandlerFactory formHandlerFactory);
    }

    internal class FormHandlerWrapperImpl<TForm, TResult> : FormHandlerWrapper<TResult>
        where TForm : IForm<TResult>
    {
        public override async Task<TResult> HandleAsync(IForm<TResult> form,
                                                           IFormHandlerFactory formHandlerFactory)
        {
            var handler = formHandlerFactory.Create<TForm, TResult>();

            // call the handler to handle the request
            var result = await handler.HandleAsync((TForm)form);

            // return the model type
            return result;
        }
    }

}