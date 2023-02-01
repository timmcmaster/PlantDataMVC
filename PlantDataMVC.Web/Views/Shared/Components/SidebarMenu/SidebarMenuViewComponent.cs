using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Models.ViewModels;
using Syncfusion.EJ2.Navigations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.MainMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public SidebarMenuViewComponent()
        {
            Console.WriteLine("Called VC constructor");
        }

        public async Task<IViewComponentResult> InvokeAsync(string targetCss, string width, string dockWidth)
        {
            var model = GetModel(targetCss, width, dockWidth);

            return View(model);
        }

        private SidebarMenuViewModel GetModel(string targetCss, string width, string dockWidth)
        {
            var sidebarMenuModel = new SidebarMenuViewModel()
            {
                TargetCss = targetCss,
                Width = width,
                DockWidth = dockWidth
            };
            
            LoadMenuModel(sidebarMenuModel);

            return sidebarMenuModel;
        }
        private void LoadMenuModel(SidebarMenuViewModel model)
        {
            var menuModel = model.Menu;

            var menuItems = new List<MenuItemViewModel>()
            {
                // Home menu
                new MenuItemViewModel(id:"item1", text:"Home", parentId:"null", url:Url.Action("Index","Home") ?? string.Empty, iconCss:"icon-home icon"),
                new MenuItemViewModel(id:"item1.1", text:"About", parentId:"item1", url:Url.Action("About", "Home") ?? string.Empty),
                new MenuItemViewModel(id:"item1.2", text:"Privacy", parentId:"item1", url:Url.Action("Privacy", "Home") ?? string.Empty),

                // Basic MVC Views menu 
                new MenuItemViewModel(id:"item2", text:"Basic MVC Views", parentId:"null", string.Empty, iconCss:"icon-plus icon"),
                new MenuItemViewModel(id:"item2.1", text:"Genera", parentId:"item2", url:Url.Action("Index", "Genus") ?? string.Empty),
                new MenuItemViewModel(id:"item2.2", text:"Plant", parentId:"item2", url:Url.Action("Index", "Plant") ?? string.Empty),
                new MenuItemViewModel(id:"item2.3", text:"Plant Seeds", parentId:"item2", url:Url.Action("Index", "SeedBatch") ?? string.Empty),
                new MenuItemViewModel(id:"item2.4", text:"Sites", parentId:"item2", url:Url.Action("Index", "Site") ?? string.Empty),
                new MenuItemViewModel(id:"item2.5", text:"Plant Stock", parentId:"item2", url:Url.Action("Index", "PlantStock") ?? string.Empty),
                new MenuItemViewModel(id:"item2.6", text:"Seed Trays", parentId:"item2", url:Url.Action("Index", "SeedTray") ?? string.Empty),
                new MenuItemViewModel(id:"item2.7", text:"Sales", parentId:"item2", url:Url.Action("Index", "SaleEvent") ?? string.Empty),

                // Syncusion Controls Views menu 
                new MenuItemViewModel(id:"item3", text:"Syncfusion Views", parentId:"null", string.Empty, iconCss:"icon-plus icon"),
                new MenuItemViewModel(id:"item3.1", text:"Genera", parentId:"item3", url:Url.Action("IndexVC", "Genus") ?? string.Empty)
                //,
                //new MenuItemViewModel(id:"item3.2", text:"Plant", parentId:"item3", url:Url.Action("Index", "Plant") ?? string.Empty),
                //new MenuItemViewModel(id:"item3.3", text:"Plant Seeds", parentId:"item3", url:Url.Action("Index", "SeedBatch") ?? string.Empty),
                //new MenuItemViewModel(id:"item3.4", text:"Sites", parentId:"item3", url:Url.Action("Index", "Site") ?? string.Empty),
                //new MenuItemViewModel(id:"item3.5", text:"Plant Stock", parentId:"item3", url:Url.Action("Index", "PlantStock") ?? string.Empty),
                //new MenuItemViewModel(id:"item3.6", text:"Seed Trays", parentId:"item3", url:Url.Action("Index", "SeedTray") ?? string.Empty),
                //new MenuItemViewModel(id:"item3.7", text:"Sales", parentId:"item3", url:Url.Action("Index", "SaleEvent") ?? string.Empty)
            };

            menuModel.MenuItems = menuItems;
            menuModel.MenuFields = new MenuFieldSettings() { ItemId = "Id", Text = "Text", ParentId = "ParentId", Url = "Url", IconCss = "IconCss" };
        }
    }
}
