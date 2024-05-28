using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.PriceListType
{
    public class PriceListTypeUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
    }
}