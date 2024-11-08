using System.Collections.Generic;

namespace PlantData.Web.Blazor.ViewModels
{
    public interface ISidebarMenuViewModel : IBaseViewModel
    {
        List<MenuItemViewModel> Items { get; set; }
        MenuFieldsViewModel Fields { get; set; }

        void Initialise();
    }
}