using Framework.Web.Forms;
using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.EditModels.Label
{
    public class BarcodeLabelsEditModel : IForm<string>
    {
        public string LayoutName { get; set; } = string.Empty;

        public IEnumerable<BarcodeLabelListEditModel> Items { get; set; } = new List<BarcodeLabelListEditModel>();
    }
}
