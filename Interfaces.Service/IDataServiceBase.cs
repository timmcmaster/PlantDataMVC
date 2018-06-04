using Interfaces.Domain;

namespace Interfaces.Service
{
    public interface IDataServiceBase<T> where T : IDomainEntity
    {
        ICreateResponse<T> Create(ICreateRequest<T> request);

        IViewResponse<T> View(IViewRequest<T> request);

        IUpdateResponse<T> Update(IUpdateRequest<T> request);

        IDeleteResponse<T> Delete(IDeleteRequest<T> request);

        IListResponse<T> List(IListRequest<T> request);
    }
}