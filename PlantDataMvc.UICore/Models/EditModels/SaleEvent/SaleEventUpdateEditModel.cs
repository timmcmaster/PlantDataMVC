using Framework.Web.Core.Forms;
using System;

namespace PlantDataMVC.UICore.Models.EditModels.SaleEvent
{
    public class SaleEventUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? Location { get; set; }
    }
}
