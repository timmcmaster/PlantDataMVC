using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public interface IMediator
    {
        //TViewModel Request<TViewModel>(IViewQuery query);
        TViewModel Request<TViewModel>(IViewQuery<TViewModel> query);
    }
}
