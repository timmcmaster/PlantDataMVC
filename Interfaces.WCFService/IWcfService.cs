using Interfaces.DTO;
using Interfaces.WcfService.Responses;

namespace Interfaces.WcfService
{
    public interface IWcfService
    {
        ICreateResponse<TDtoOut> Create<TDtoIn, TDtoOut>(TDtoIn item) where TDtoIn : class, IDto
                                                                      where TDtoOut : class, IDto;

        IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : class, IDto;

        IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item) where TDtoIn : class, IDto
                                                                              where TDtoOut : class, IDto;

        IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : class, IDto;

        IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : class, IDto;
    }
}