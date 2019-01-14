namespace Interfaces.Service.Responses
{
    public interface ICreateResponse<T>: IResponse
    {
        int Id { get; set; }
        T Item { get; set; }
    }
}