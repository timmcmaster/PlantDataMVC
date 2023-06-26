namespace PlantDataMvc.Api.Reports.BarcodeLabels.Models
{
    public class BarcodeLabelItemModel
    {
        public string LabelText { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string BarcodeText { get; set; } = string.Empty;

        public BarcodeLabelItemModel()
        {
        }
    }
}
