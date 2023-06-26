namespace PlantDataMVC.Api.Reports.InfoLabels.Models
{
    public class InfoLabelItemModel
    {
        public int LabelQuantity { get; set; }

        public string SpeciesBinomial { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public InfoLabelItemModel()
        {
        }
    }
}
