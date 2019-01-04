using Interfaces.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.Service
{
    [ServiceContract]
    public interface IDataServiceBase<T> where T : IDomainEntity
    {
        // POST: api/Plant
        [OperationContract]
        ICreateResponse<T> Create(T item);

        // GET: api/Plant/5
        [OperationContract]
        IViewResponse<T> View(int id);

        // PUT: api/Plant/5
        [OperationContract]
        IUpdateResponse<T> Update(T item);

        // DELETE: api/Plant/5
        [OperationContract]
        IDeleteResponse<T> Delete(int id);

        // GET: api/Plant
        [OperationContract]
        IListResponse<T> List();
    }
}