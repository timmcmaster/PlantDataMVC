namespace Interfaces.Service
{
    public interface IDeleteRequest<T> : IRequest
    {
        int Id { get; set; }
    }
}