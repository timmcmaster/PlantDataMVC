using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.ProductType
{
    public class ProductTypeCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
    }
}