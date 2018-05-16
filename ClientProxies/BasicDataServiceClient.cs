using Interfaces.Domain;
using Interfaces.Service;
using System.ServiceModel;
using System;
using System.ServiceModel.Channels;

namespace ClientProxies
{
    public class BasicDataServiceClient<T> : ClientBase<IBasicDataService<T>>, IBasicDataService<T> where T : IDomainEntity
    {
        // endpoint is going to be specific to service type (not generic)
        public BasicDataServiceClient(string endpoint) : base(endpoint)
        {
        }

        public BasicDataServiceClient(Binding binding, EndpointAddress address) : base(binding, address)
        {
        }

        #region IBasicDataService implementation
        public ICreateResponse<T> Create(ICreateRequest<T> request)
        {
            return Channel.Create(request);
        }

        public IDeleteResponse<T> Delete(IDeleteRequest<T> request)
        {
            return Channel.Delete(request);
        }

        public IListResponse<T> List(IListRequest<T> request)
        {
            return Channel.List(request);
        }

        public IUpdateResponse<T> Update(IUpdateRequest<T> request)
        {
            return Channel.Update(request);
        }

        public IViewResponse<T> View(IViewRequest<T> request)
        {
            return Channel.View(request);
        }
        #endregion

    }
}
