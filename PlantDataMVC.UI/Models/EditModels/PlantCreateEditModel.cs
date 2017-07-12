using PlantDataMVC.UI.Forms;

namespace PlantDataMVC.UI.Models
{
    public class PlantCreateEditModel : IForm
    {
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }

        public PlantCreateEditModel()
            : this("", "", "", "", 0, true)
        {
        }

        public PlantCreateEditModel(string genus, string species, string commonName, string description, int propagationTime, bool native)
        {
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Description = description;
            PropagationTime = propagationTime;
            Native = native;
        }
    }
}