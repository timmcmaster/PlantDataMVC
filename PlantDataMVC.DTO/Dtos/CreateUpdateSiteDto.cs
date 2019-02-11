namespace PlantDataMVC.DTO.Dtos
{
    public class CreateUpdateSiteDto : IDto
    {
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}