namespace Interfaces.WcfService.Responses
{
    public interface ICreateResponse<T>: IResponse
    {
        int Id { get; set; }
        T Item { get; set; }
    }
}