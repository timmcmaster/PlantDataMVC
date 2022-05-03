using System.Threading;
using System.Threading.Tasks;

namespace Framework.Web.Views
{
    // The query is bound to the model type it acts on, so that queries aren't used against the wrong model
    // TQuery is covariant so IQueryHandler<Query<ViewModel>,ViewModel> can be assigned to var of type IQueryHandler<QueryBase<ViewModel>,ViewModel> 
    // Why do we need covariance?
    public interface IQueryHandler<in TQuery, TViewModel> where TQuery : IQuery<TViewModel>
    {
        //Task<TViewModel> HandleAsync(TQuery query);
        Task<TViewModel> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}