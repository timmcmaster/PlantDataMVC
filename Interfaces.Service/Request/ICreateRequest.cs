namespace Interfaces.Service
{
    public interface ICreateRequest<T>: IRequest
    {
        T Item { get; set; }
    }
}