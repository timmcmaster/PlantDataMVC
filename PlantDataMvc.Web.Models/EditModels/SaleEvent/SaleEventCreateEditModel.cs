using Framework.Web.Forms;
using System;

namespace PlantDataMVC.Web.Models.EditModels.SaleEvent
{
    public class SaleEventCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? Location { get; set; }
    }
}
