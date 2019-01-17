using Interfaces.DTO;
using Interfaces.Service.Responses;

namespace Interfaces.WCFService
{
    public interface IWcfService
    {
        ICreateResponse<TDtoOut> Create<TDtoIn,TDtoOut>(TDtoIn item) where TDtoIn: IDtoEntity 
                                                                     where TDtoOut : IDtoEntity;

        IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : IDtoEntity;

        IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item) where TDtoIn: IDtoEntity 
                                                                              where TDtoOut : IDtoEntity;

        IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : IDtoEntity;

        IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : IDtoEntity;
    }
}