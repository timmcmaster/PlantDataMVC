namespace Interfaces.Service.Responses
{
    public interface IViewResponse<T>: IResponse
    {
        T Item { get; set; }
    }
}