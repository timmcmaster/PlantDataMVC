using Framework.Web.Forms;
using System;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantSeedUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int? SiteId { get; set; }
    }
}
