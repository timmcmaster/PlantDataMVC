using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Layout
{
    public class SidebarMenuViewModel : ISidebarMenuViewModel
    {
        public List<MenuItemViewModel> Items { get; set; } = new();
        public MenuFieldsViewModel Fields { get; set; } = new();
    }
}
