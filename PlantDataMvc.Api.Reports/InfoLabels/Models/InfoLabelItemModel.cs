namespace PlantDataMVC.Api.Reports.InfoLabels.Models
{
    public class InfoLabelItemModel
    {
        public int LabelQuantity { get; set; }

        public string SpeciesBinomial { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }

        public InfoLabelItemModel()
        {
        }
    }
}
