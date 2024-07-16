using System.Collections.Generic;

namespace PlantData.Web.Blazor.SharedComponents.Layout
{
    public interface ISidebarMenuViewModel
    {
        List<MenuItemViewModel> Items { get; set; }
        MenuFieldsViewModel Fields { get; set; }
    }
}