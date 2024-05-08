using Framework.Web.Forms;
using PlantDataMVC.Web.Models.EditModels.Label;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.EditModels.Label
{
    public class BarcodeLabelsEditModel : IForm<string>
    {
        public string LayoutName { get; set; } = string.Empty;

        public IEnumerable<BarcodeLabelListEditModel> Items { get; set; } = new List<BarcodeLabelListEditModel>();
    }
}
