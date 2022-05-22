using System.Collections.Generic;

namespace Framework.Web.Core.Views
{
    // TViewModel is contravariant so IQuery<ViewModel> can be assigned to var of type IQuery<DerivedViewModel> 
    // Why is it needed?
    public interface IQuery<out TViewModel> : MediatR.IRequest<TViewModel>
    {
    }

    public interface IQueryForList<TListItem, out TViewModel> : IQuery<TViewModel> where TViewModel :IEnumerable<TListItem>
    {
    }
}
