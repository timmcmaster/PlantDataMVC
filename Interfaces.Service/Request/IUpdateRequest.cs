namespace Interfaces.Service
{
    public interface IUpdateRequest<T>: IRequest
    {
        T Item { get; set; }
    }
}