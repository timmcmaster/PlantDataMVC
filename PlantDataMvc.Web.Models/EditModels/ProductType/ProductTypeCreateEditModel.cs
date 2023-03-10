using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.ProductType
{
    public class ProductTypeCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
    }
}