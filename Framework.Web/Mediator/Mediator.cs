﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
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

        public async Task<TViewModel> Request<TViewModel>(IViewQuery<TViewModel> query,
                                                          CancellationToken cancellationToken = default)
        {
            // the actual definitions are not as IViewQuery<TViewModel> but as a type that implements that (e.g. GenusIndexQuery)
            // and the handlers retrieved from the factory are defined against actual query and view model types
            var handler =
                (ViewHandlerWrapper<TViewModel>)Activator.CreateInstance(
                    typeof(ViewHandlerWrapperImpl<,>).MakeGenericType(query.GetType(), typeof(TViewModel)));

            // call the handler to handle the request (ConfigureAwait(false) means that resumed task does not run on main context)
            var viewModel = await handler.HandleAsync(query, cancellationToken, _viewHandlerFactory)
                                                .ConfigureAwait(false);

            // return the model type
            return viewModel;
        }

        public async Task<TResult> Send<TResult>(IForm<TResult> form, CancellationToken cancellationToken = default)
        {
            // the actual form definitions are not as IForm<TResult> but as a type that implements that (e.g. GenusCreateEditModel)
            // and the handlers retrieved from the factory are defined against actual form and result types
            var handler =
                (FormHandlerWrapper<TResult>) Activator.CreateInstance(
                    typeof(FormHandlerWrapperImpl<,>).MakeGenericType(form.GetType(), typeof(TResult)));

            // call the handler to handle the request (ConfigureAwait(false) means that resumed task does not run on main context)
            var result = await handler.HandleAsync(form, cancellationToken, _formHandlerFactory)
                                          .ConfigureAwait(false);

            // return the model type
            return result;
        }
    }

    internal abstract class ViewHandlerWrapper<TViewModel>
    {
        public abstract Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query,
                                                     CancellationToken cancellationToken,
                                                     IViewHandlerFactory viewHandlerFactory);
    }

    internal class ViewHandlerWrapperImpl<TQuery, TViewModel> : ViewHandlerWrapper<TViewModel>
        where TQuery : IViewQuery<TViewModel>
    {
        public override Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query,
                                                           CancellationToken cancellationToken,
                                                           IViewHandlerFactory viewHandlerFactory)
        {
            var handler = viewHandlerFactory.Create<TQuery, TViewModel>();

            // return the task to handle the request
            // If the handle method allows cancellation, pass it in here
            return handler.HandleAsync((TQuery) query);
        }
    }

    internal abstract class FormHandlerWrapper<TResult>
    {
        public abstract Task<TResult> HandleAsync(IForm<TResult> form,
                                                  CancellationToken cancellationToken,
                                                  IFormHandlerFactory formHandlerFactory);
    }

    internal class FormHandlerWrapperImpl<TForm, TResult> : FormHandlerWrapper<TResult>
        where TForm : IForm<TResult>
    {
        public override Task<TResult> HandleAsync(IForm<TResult> form,
                                                        CancellationToken cancellationToken,
                                                        IFormHandlerFactory formHandlerFactory)
        {
            var handler = formHandlerFactory.Create<TForm, TResult>();

            // return the task to handle the request
            // If the handle method allows cancellation, pass it in here
            return handler.HandleAsync((TForm) form);
        }
    }
}