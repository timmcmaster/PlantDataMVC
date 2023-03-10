using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.ProductType
{
    public class ProductTypeUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}