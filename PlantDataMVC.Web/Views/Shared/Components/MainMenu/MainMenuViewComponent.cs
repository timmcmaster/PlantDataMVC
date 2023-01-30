using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using Syncfusion.EJ2.Navigations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.MainMenu
{
    public class MainMenuViewComponent : ViewComponent
    {
        public MainMenuViewComponent()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = GetMenuModel();

            return View(model);
        }

        private MenuViewModel GetMenuModel()
        {
            var menuModel = new MenuViewModel();

            var menuItems = new List<MenuItemViewModel>()
            {
                new MenuItemViewModel(id:"item1", text:"Home", parentId:"null", url:Url.Action("Index","Home") ?? string.Empty, iconCss:"e-icons home"),

                new MenuItemViewModel(id:"item2", text:"Genera", parentId:"null", url:Url.Action("IndexVC", "Genus") ?? string.Empty),
                new MenuItemViewModel(id:"item2.1", text:"New", parentId:"item2", url:Url.Action("New", "Genus") ?? string.Empty),

                new MenuItemViewModel(id:"item3", text:"Plant", parentId:"null", url:Url.Action("Index", "Plant") ?? string.Empty),
                new MenuItemViewModel(id:"item3.1", text:"New", parentId:"item3", url:Url.Action("New", "Plant") ?? string.Empty),

                new MenuItemViewModel(id:"item4", text:"Plant Seeds", parentId:"null", url:Url.Action("Index", "SeedBatch") ?? string.Empty),
                new MenuItemViewModel(id:"item4.1", text:"New", parentId:"item4", url:Url.Action("New", "SeedBatch") ?? string.Empty),

                new MenuItemViewModel(id:"item5", text:"Sites", parentId:"null", url:Url.Action("Index", "Site") ?? string.Empty),
                new MenuItemViewModel(id:"item5.1", text:"New", parentId:"item5", url:Url.Action("New", "Site") ?? string.Empty),

                new MenuItemViewModel(id:"item6", text:"Plant Stock", parentId:"null", url:Url.Action("Index", "PlantStock") ?? string.Empty),
                new MenuItemViewModel(id:"item6.1", text:"New", parentId:"item6", url:Url.Action("New", "PlantStock") ?? string.Empty),

                new MenuItemViewModel(id:"item7", text:"Seed Trays", parentId:"null", url:Url.Action("Index", "SeedTray") ?? string.Empty),
                new MenuItemViewModel(id:"item7.1", text:"New", parentId:"item7", url:Url.Action("New", "SeedTray") ?? string.Empty),

                new MenuItemViewModel(id:"item8", text:"Sales", parentId:"null", url:Url.Action("Index", "SaleEvent") ?? string.Empty),
                new MenuItemViewModel(id:"item8.1", text:"New", parentId:"item8", url:Url.Action("New", "SaleEvent") ?? string.Empty),

                new MenuItemViewModel(id:"item9", text:"About", parentId:"null", url:Url.Action("About", "Home") ?? string.Empty),

                new MenuItemViewModel(id:"item10", text:"Privacy", parentId:"null", url:Url.Action("Privacy", "Home") ?? string.Empty)
            };

            menuModel.MenuItems = menuItems;
            menuModel.MenuFields = new MenuFieldSettings() { ItemId = "Id", Text = "Text", ParentId = "ParentId", Url = "Url", IconCss = "IconCss" };

            return menuModel;
        }
    }
}
