using System.Threading.Tasks;

namespace Framework.Web.Views
{
    public interface IViewHandler<TView,TQuery> where TView : IViewModel
                                                where TQuery : IViewQuery
    {
        Task<TView> HandleAsync(TQuery query);
    }
}