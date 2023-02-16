using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.PriceListType
{
    public class PriceListTypeCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}