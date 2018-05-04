namespace Interfaces.Service
{
    public interface ICreateResponse<T>: IResponse
    {
        int Id { get; set; }
        T Item { get; set; }
    }
}