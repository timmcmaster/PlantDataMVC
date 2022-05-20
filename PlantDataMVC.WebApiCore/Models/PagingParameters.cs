namespace PlantDataMVC.WebApiCore.Models
{
    public class PagingParameters : IPagingParameters
    {
        const int MaxPageSize = 100;
        private int _pageSize = MaxPageSize;

        public int Page { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
