using Framework.Web.Forms;

namespace PlantData.Web.Blazor.UIModels.EditModels.ProductType
{
    public class ProductTypeUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}