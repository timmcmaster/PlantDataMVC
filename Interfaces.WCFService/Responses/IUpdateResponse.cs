namespace Interfaces.WcfService.Responses
{
    public interface IUpdateResponse<T> : IResponse
    {
        T Item { get; set; }
    }
}