namespace PlantDataMVC.Api.Reports.BarcodeLabels.Models;

public class BarcodeLabelReportModel
{
    public BarcodeLabelReportModel()
    {
        LabelItems = new List<BarcodeLabelItemModel>();
    }

    public List<BarcodeLabelItemModel> LabelItems { get; set; }
}
