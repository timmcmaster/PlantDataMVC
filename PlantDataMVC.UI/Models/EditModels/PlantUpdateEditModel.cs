using PlantDataMVC.UI.Forms;

namespace PlantDataMVC.UI.Models
{
    public class PlantUpdateEditModel : IForm
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