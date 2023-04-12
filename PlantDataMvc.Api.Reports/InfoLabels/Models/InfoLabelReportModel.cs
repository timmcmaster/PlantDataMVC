using PlantDataMVC.Api.Models.DataModels;
using System.Collections.Generic;

namespace PlantDataMVC.Api.Reports.InfoLabels.Models
{
    public class InfoLabelReportModel
    {
        public InfoLabelReportModel()
        {
            LabelItems = new List<InfoLabelItemModel>();
        }

        public List<InfoLabelItemModel> LabelItems { get; set; }
    }
}
