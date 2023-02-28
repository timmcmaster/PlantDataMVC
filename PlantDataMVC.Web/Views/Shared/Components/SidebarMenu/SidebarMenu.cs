﻿using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using Syncfusion.EJ2.Navigations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            var mainMenuHeaderText = PlantDataMvcConstants.UseBasicMvcViews ? "Menu - Basic MVC" : "Menu - Syncfusion";

            var menuItems = new List<MenuItemViewModel>()
            {
                // Menu header
                new MenuItemViewModel(id:"sfHeader", text:mainMenuHeaderText, parentId:"null", url:string.Empty, iconCss:"icon"),

                // Home menu
                new MenuItemViewModel(id:"sfHome", text:"Home", parentId:"null", url:Url.Action("Index",@PlantDataMvcAppControllers.Home) ?? string.Empty, iconCss:"fa fa-solid fa-house"),
                new MenuItemViewModel(id:"sfHomeAbout", text:"About", parentId:"sfHome", url:Url.Action("About", @PlantDataMvcAppControllers.Home) ?? string.Empty),
                new MenuItemViewModel(id:"sfHomePrivacy", text:"Privacy", parentId:"sfHome", url:Url.Action("Privacy", @PlantDataMvcAppControllers.Home) ?? string.Empty),

                // Basic MVC Views menu 
                new MenuItemViewModel(id:"sfPlant", text:"Plant Definitions", parentId:"null", url : string.Empty, iconCss:"fa fa-solid fa-tree"),
                new MenuItemViewModel(id:"sfPlantGenera", text:"Genera", parentId:"sfPlant", url:Url.Action("Index", PlantDataMvcAppControllers.Genus) ?? string.Empty),
                new MenuItemViewModel(id:"sfPlantSpecies", text:"Species", parentId:"sfPlant", url:Url.Action("Index", PlantDataMvcAppControllers.Plant) ?? string.Empty),

                new MenuItemViewModel(id:"sfInv", text:"Inventory", parentId:"null", url : string.Empty, iconCss:"fa fa-solid fa-cubes"),
                new MenuItemViewModel(id:"sfInvSeeds", text:"Seeds", parentId:"sfInv", url:Url.Action("Index", PlantDataMvcAppControllers.SeedBatch) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvSites", text:"Seed Collection Sites", parentId:"sfInv", url:Url.Action("Index", @PlantDataMvcAppControllers.Site) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvTrays", text:"Seed Trays", parentId:"sfInv", url:Url.Action("Index", PlantDataMvcAppControllers.SeedTray) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvStock", text:"Plant Stock (static)", parentId:"sfInv", url:Url.Action("Index", @PlantDataMvcAppControllers.PlantStock) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvTransactions", text:"Plant Stock (from Transactions)", parentId:"sfInv", url:Url.Action("StockSummary", PlantDataMvcAppControllers.Transaction) ?? string.Empty),

                new MenuItemViewModel(id:"sfSales", text:"Sales", parentId:"null", url : string.Empty, iconCss:"fa fa-solid fa-calendar"),
                new MenuItemViewModel(id:"sfSalesEvents", text:"Sale Events", parentId:"sfSales", url:Url.Action("Index", PlantDataMvcAppControllers.SaleEvent) ?? string.Empty),

                new MenuItemViewModel(id:"sfProd", text:"Products and Pricing", parentId:"null", url:string.Empty, iconCss:"fa fa-solid fa-dollar-sign"),
                new MenuItemViewModel(id:"sfProdProducts", text:"Products", parentId:"sfProd", url:Url.Action("Index", PlantDataMvcAppControllers.ProductType) ?? string.Empty),
                new MenuItemViewModel(id:"sfProdPricelists", text:"Price Lists", parentId:"sfProd", url:Url.Action("Index", PlantDataMvcAppControllers.PriceListType) ?? string.Empty)
            };

            menuModel.MenuItems = menuItems;
            menuModel.MenuFields = new MenuFieldSettings() { ItemId = "Id", Text = "Text", ParentId = "ParentId", Url = "Url", IconCss = "IconCss" };
        }
    }
}
