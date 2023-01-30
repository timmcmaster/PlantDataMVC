using Syncfusion.EJ2.Navigations;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public MenuFieldSettings MenuFields { get; set; } = new();
    }
}
