using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.WCFServices
{
    public class WcfPlantDataService : IWcfPlantDataService
    {
        private IDataServiceBase<Plant> _ds;

        public WcfPlantDataService(IDataServiceBase<Plant> ds)
        {
            _ds = ds;
        }

        public ICreateResponse<Plant> Create(ICreateRequest<Plant> request)
        {
            return _ds.Create(request);
        }

        public IViewResponse<Plant> View(IViewRequest<Plant> request)
        {
            return _ds.View(request);
        }

        public IUpdateResponse<Plant> Update(IUpdateRequest<Plant> request)
        {
            return _ds.Update(request);
        }

        public IDeleteResponse<Plant> Delete(IDeleteRequest<Plant> request)
        {
            return _ds.Delete(request);
        }

        public IListResponse<Plant> List(IListRequest<Plant> request)
        {
            return _ds.List(request);
        }
    }
}
