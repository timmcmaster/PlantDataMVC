namespace Interfaces.Service
{
    public interface IViewRequest<T>: IRequest
    {
        int Id { get; set; }
    }
}