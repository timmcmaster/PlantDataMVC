using Framework.Web.Forms;
using System.Collections.Generic;

namespace PlantData.Web.Blazor.UIModels.EditModels.Label
{
    public class PlantLabelGridEditModel : IForm<string>
    {
        public IEnumerable<PlantLabelListEditModel> Items { get; set; } = new List<PlantLabelListEditModel>();
    }
}
