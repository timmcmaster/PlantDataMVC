namespace PlantDataMVC.Api.Models.ServiceModels
{
    public class FetchBarcodeLabelReportResponseDto : ResponseDto
    {
        public string? ReportDocument { get; set; }

        public FetchBarcodeLabelReportResponseDto()
        {
        }
    }
}
