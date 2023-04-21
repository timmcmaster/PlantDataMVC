using Framework.Web.Forms;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.EditModels.Label
{
    public class BarcodeLabelGridEditModel : IForm<string>
    {
        public IEnumerable<BarcodeLabelListEditModel> Items { get; set; } = new List<BarcodeLabelListEditModel>();
    }
}
