namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchBarcodeLabelReportAsyncResponseDTO: ResponseDTO
    {
        public string? ReportDocument { get; set; }

        public FetchBarcodeLabelReportAsyncResponseDTO()
        {
        }
    }
}
