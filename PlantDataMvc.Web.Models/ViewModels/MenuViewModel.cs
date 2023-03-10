using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public MenuFieldsViewModel MenuFields { get; set; } = new();
    }
}
