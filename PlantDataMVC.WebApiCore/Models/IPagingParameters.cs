namespace PlantDataMVC.WebApiCore.Models
{
    public interface IPagingParameters
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
