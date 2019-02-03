using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public TViewModel Request<TViewModel>(IViewQuery query)
        {
            // resolve the handler for this query type and viewmodel type
            var handler =_viewHandlerFactory.Create<typeof(IViewQuery),TViewModel>()
            
            // call the handler to handle the request

            // return the model type
            
        }
    }
}
