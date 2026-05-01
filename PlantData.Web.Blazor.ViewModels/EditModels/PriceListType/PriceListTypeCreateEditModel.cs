using Framework.Web.Forms;

namespace PlantData.Web.Blazor.UIModels.EditModels.PriceListType
{
    public class PriceListTypeCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}
