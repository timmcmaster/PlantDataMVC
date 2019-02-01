namespace Interfaces.WcfService.Responses
{
    public interface IViewResponse<T> : IResponse
    {
        T Item { get; set; }
    }
}