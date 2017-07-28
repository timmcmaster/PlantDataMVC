using Framework.Web.Forms;
using System;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
