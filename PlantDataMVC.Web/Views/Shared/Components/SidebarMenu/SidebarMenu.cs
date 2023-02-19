using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using Syncfusion.EJ2.Navigations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Shared.Components.MainMenu
{
    public class SidebarMenu : ViewComponent
    {
        public SidebarMenu()
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
                // Basic MVC menu header
                new MenuItemViewModel(id:"basicItem0", text:"Basic MVC", parentId:"null", url:string.Empty, iconCss:"icon"),

                // Home menu
                new MenuItemViewModel(id:"basicItem1", text:"Home", parentId:"null", url:Url.Action("Index",@PlantDataMvcAppControllers.Home) ?? string.Empty, iconCss:"icon-home icon"),
                new MenuItemViewModel(id:"basicItem1.1", text:"About", parentId:"basicItem1", url:Url.Action("About", @PlantDataMvcAppControllers.Home) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem1.2", text:"Privacy", parentId:"basicItem1", url:Url.Action("Privacy", @PlantDataMvcAppControllers.Home) ?? string.Empty),

                // Basic MVC Views menu 
                new MenuItemViewModel(id:"basicItem2", text:"Views", parentId:"null", url : string.Empty, iconCss:"icon-plus icon"),
                new MenuItemViewModel(id:"basicItem2.1", text:"Genera", parentId:"basicItem2", url:Url.Action("Index", PlantDataMvcAppControllers.Genus) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.2", text:"Plant", parentId:"basicItem2", url:Url.Action("Index", PlantDataMvcAppControllers.Plant) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.3", text:"Plant Seeds", parentId:"basicItem2", url:Url.Action("Index", PlantDataMvcAppControllers.SeedBatch) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.4", text:"Sites", parentId:"basicItem2", url:Url.Action("Index", @PlantDataMvcAppControllers.Site) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.5", text:"Plant Stock", parentId:"basicItem2", url:Url.Action("Index", @PlantDataMvcAppControllers.PlantStock) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.6", text:"Seed Trays", parentId:"basicItem2", url:Url.Action("Index", PlantDataMvcAppControllers.SeedTray) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.7", text:"Sales", parentId:"basicItem2", url:Url.Action("Index", PlantDataMvcAppControllers.SaleEvent) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem2.8", text:"Transaction Stock Summary", parentId:"basicItem2", url:Url.Action("StockSummary", PlantDataMvcAppControllers.Transaction) ?? string.Empty),

                new MenuItemViewModel(id:"basicItem3", text:"Maintenance", parentId:"null", url:string.Empty, iconCss:"icon-settings icon"),
                new MenuItemViewModel(id:"basicItem3.1", text:"Products", parentId:"basicItem3", url:Url.Action("Index", PlantDataMvcAppControllers.ProductType) ?? string.Empty),
                new MenuItemViewModel(id:"basicItem3.2", text:"Price Lists", parentId:"basicItem3", url:Url.Action("Index", PlantDataMvcAppControllers.PriceListType) ?? string.Empty),

                MenuItemViewModel.CreateSeparator(id:"item4", parentId:"null"),

                // Syncfusion menu header
                new MenuItemViewModel(id:"sfItem0", text:"Syncfusion Controls", parentId:"null", url:string.Empty, iconCss:"icon"),

                // Home menu
                new MenuItemViewModel(id:"sfItem1", text:"Home", parentId:"null", url:Url.Action("Index",@PlantDataMvcAppControllers.Home) ?? string.Empty, iconCss:"icon-home icon"),
                new MenuItemViewModel(id:"sfItem1.1", text:"About", parentId:"sfItem1", url:Url.Action("About", @PlantDataMvcAppControllers.Home) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem1.2", text:"Privacy", parentId:"sfItem1", url:Url.Action("Privacy", @PlantDataMvcAppControllers.Home) ?? string.Empty),

                // Syncfusion Controls Views menu 
                new MenuItemViewModel(id:"sfItem2", text:"Syncfusion Views", parentId:"null", url:string.Empty, iconCss:"icon-plus icon"),
                new MenuItemViewModel(id:"sfItem2.1", text:"Genera", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.Genus) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.2", text:"Plant", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.Plant) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.3", text:"Plant Seeds", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.SeedBatch) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.4", text:"Sites", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.Site) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.5", text:"Plant Stock", parentId:"sfItem2", url:Url.Action("IndexVC", @PlantDataMvcAppControllers.PlantStock) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.6", text:"Seed Trays", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.SeedTray) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem2.7", text:"Sales", parentId:"sfItem2", url:Url.Action("IndexVC", PlantDataMvcAppControllers.SaleEvent) ?? string.Empty),

                new MenuItemViewModel(id:"sfItem3", text:"Maintenance", parentId:"null", url:string.Empty, iconCss:"icon-settings icon"),
                new MenuItemViewModel(id:"sfItem3.1", text:"Products", parentId:"sfItem3", url:Url.Action("IndexVC", PlantDataMvcAppControllers.ProductType) ?? string.Empty),
                new MenuItemViewModel(id:"sfItem3.2", text:"Price Lists", parentId:"sfItem3", url:Url.Action("IndexVC", PlantDataMvcAppControllers.PriceListType) ?? string.Empty),
            };

            menuModel.MenuItems = menuItems;
            menuModel.MenuFields = new MenuFieldSettings() { ItemId = "Id", Text = "Text", ParentId = "ParentId", Url = "Url", IconCss = "IconCss" };
        }
    }
}
