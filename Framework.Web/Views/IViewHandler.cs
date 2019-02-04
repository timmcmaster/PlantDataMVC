using System.Threading.Tasks;

namespace Framework.Web.Views
{
    // Use the below once we need specific queries per model type
    // The query is bound to the model type it acts on, so that queries aren't used against the wrong model
    // TQuery is covariant so IViewHandler<Query<ViewModel>,ViewModel> can be assigned to var of type IViewHandler<QueryBase<ViewModel>,ViewModel> 
    // Why do we need covariance?
    public interface IViewHandler<in TQuery, TViewModel> where TViewModel : IViewModel
                                                      where TQuery : IViewQuery<TViewModel>
    {
        Task<TViewModel> HandleAsync(TQuery query);
    }
}