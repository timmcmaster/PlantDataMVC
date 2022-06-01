using Framework.Web.Core.Forms;
using System;

namespace PlantDataMVC.UICore.Models.EditModels.SaleEvent
{
    public class SaleEventCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
        public DateTime SaleDate { get; set; }
        public string Location { get; set; }
    }
}
