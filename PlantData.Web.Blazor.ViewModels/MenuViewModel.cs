using System.Collections.Generic;

namespace PlantData.Web.Blazor.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public MenuFieldsViewModel MenuFields { get; set; } = new();
    }
}
