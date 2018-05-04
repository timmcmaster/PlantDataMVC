namespace Interfaces.Service
{
    public interface IUpdateResponse<T> : IResponse
    {
        T Item { get; set; }
    }
}