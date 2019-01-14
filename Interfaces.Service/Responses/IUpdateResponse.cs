namespace Interfaces.Service.Responses
{
    public interface IUpdateResponse<T> : IResponse
    {
        T Item { get; set; }
    }
}