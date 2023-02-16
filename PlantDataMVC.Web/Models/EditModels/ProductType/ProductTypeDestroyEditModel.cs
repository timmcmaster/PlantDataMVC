using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.ProductType
{
    public class ProductTypeDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}