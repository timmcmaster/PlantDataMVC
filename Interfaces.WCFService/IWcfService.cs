using Interfaces.DTO;
using Interfaces.Service.Responses;

namespace Interfaces.WCFService
{
    public interface IWcfService
    {
        ICreateResponse<TDtoOut> Create<TDtoIn,TDtoOut>(TDtoIn item) where TDtoIn: IDto 
                                                                     where TDtoOut : IDto;

        IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : IDto;

        IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item) where TDtoIn: IDto 
                                                                              where TDtoOut : IDto;

        IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : IDto;

        IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : IDto;
    }
}