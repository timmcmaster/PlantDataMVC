using System.Threading.Tasks;
using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public interface IMediator
    {
        Task<TViewModel> Request<TViewModel>(IViewQuery<TViewModel> query) where TViewModel : IViewModel;
        Task<TViewModel> Send<TViewModel>(IViewQuery<TViewModel> query) where TViewModel : IViewModel;
    }
}
