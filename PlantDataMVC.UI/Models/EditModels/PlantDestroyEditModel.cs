using PlantDataMVC.UI.Forms;

namespace PlantDataMVC.UI.Models
{
    public class PlantDestroyEditModel : IForm
    {
        public int Id { get; set; }

        public PlantDestroyEditModel()
            : this(0)
        {
        }

        public PlantDestroyEditModel(int id)
        {
            Id = id;
        }
    }
}