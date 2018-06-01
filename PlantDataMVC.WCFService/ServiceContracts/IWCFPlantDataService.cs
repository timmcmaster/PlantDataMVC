using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    [ServiceContract]
    public interface IWcfPlantDataService
    {
        [OperationContract]
        ICreateResponse<Plant> Create(ICreateRequest<Plant> request);

        [OperationContract]
        IViewResponse<Plant> View(IViewRequest<Plant> request);

        [OperationContract]
        IUpdateResponse<Plant> Update(IUpdateRequest<Plant> request);

        [OperationContract]
        IDeleteResponse<Plant> Delete(IDeleteRequest<Plant> request);

        [OperationContract]
        IListResponse<Plant> List(IListRequest<Plant> request);
    }
}
