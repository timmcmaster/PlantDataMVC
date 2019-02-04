using Framework.Web.Forms;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }
    }
}