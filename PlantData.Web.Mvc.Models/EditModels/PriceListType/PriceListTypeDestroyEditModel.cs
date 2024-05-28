using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.PriceListType
{
    public class PriceListTypeDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}