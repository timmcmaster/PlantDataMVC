using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.PriceListType
{
    public class PriceListTypeUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}