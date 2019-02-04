using System;
using System.Threading.Tasks;
using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public class Mediator: IMediator
    {
        private readonly IViewHandlerFactory _viewHandlerFactory;

        public Mediator(IViewHandlerFactory viewHandlerFactory)
        {
            _viewHandlerFactory = viewHandlerFactory;
        }

        public async Task<TViewModel> Send<TViewModel>(IViewQuery<TViewModel> query) where TViewModel : IViewModel
        {
            // resolve the handler for this query type and viewmodel type
            // problem that the actual definitions are not as IViewQuery<TViewModel> but as a type that implements that (e.g. GenusIndexQuery)
            var queryType = query.GetType();

            var handler =
                (HandlerWrapper<TViewModel>) Activator.CreateInstance(typeof(HandlerWrapperImpl<,>).MakeGenericType(queryType, typeof(TViewModel)));
            

            // call the handler to handle the request
            var viewmodel = await handler.HandleAsync(query,_viewHandlerFactory);

            // return the model type
            return viewmodel;
        }
    }

    internal abstract class HandlerWrapper<TViewModel> where TViewModel : IViewModel
    {
        public abstract Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query,
                                                           IViewHandlerFactory viewHandlerFactory);
    }

        internal class HandlerWrapperImpl<TQuery,TViewModel> : HandlerWrapper<TViewModel> where TQuery : IViewQuery<TViewModel> where TViewModel : IViewModel
    {
        public override async Task<TViewModel> HandleAsync(IViewQuery<TViewModel> query, IViewHandlerFactory viewHandlerFactory)
        {
            var handler = viewHandlerFactory.Create<TQuery, TViewModel>();

            // call the handler to handle the request
            var viewModel = await handler.HandleAsync((TQuery)query);

            // return the model type
            return viewModel;

        }
    }
}
