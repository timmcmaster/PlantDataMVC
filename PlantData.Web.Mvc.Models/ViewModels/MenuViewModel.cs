using System.Collections.Generic;

namespace PlantData.Web.Mvc.Models.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public MenuFieldsViewModel MenuFields { get; set; } = new();
    }
}
