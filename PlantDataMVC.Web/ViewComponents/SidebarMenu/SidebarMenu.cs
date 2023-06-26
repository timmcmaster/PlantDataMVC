using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMVC.Web.Constants;
using PlantDataMVC.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.SidebarMenu
{
    public class SidebarMenu : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public SidebarMenu(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(string targetCss, string width, string dockWidth)
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
                DockWidth = dockWidth,
                UseBasicMvcViews = _useBasicMvcViews
            };

            LoadMenuModel(sidebarMenuModel);

            return sidebarMenuModel;
        }

        private void LoadMenuModel(SidebarMenuViewModel model)
        {
            var menuModel = model.Menu;

            var mainMenuHeaderText = model.UseBasicMvcViews ? "Menu - Basic MVC" : "Menu - Syncfusion";

            var menuItems = new List<MenuItemViewModel>()
            {
                // Menu header
                new MenuItemViewModel(id:"sfHeader", text:mainMenuHeaderText, parentId:"null", url:string.Empty, iconCss:"icon"),

                // Home menu
                new MenuItemViewModel(id:"sfHome", text:"Home", parentId:"null", url:Url.Action("Index",@PlantDataMvcAppControllers.Home) ?? string.Empty, iconCss:"bi-house-fill"),
                new MenuItemViewModel(id:"sfHomeAbout", text:"About", parentId:"sfHome", url:Url.Action("About", @PlantDataMvcAppControllers.Home) ?? string.Empty),
                new MenuItemViewModel(id:"sfHomePrivacy", text:"Privacy", parentId:"sfHome", url:Url.Action("Privacy", @PlantDataMvcAppControllers.Home) ?? string.Empty),

                // Basic MVC Views menu 
                new MenuItemViewModel(id:"sfPlant", text:"Plant Definitions", parentId:"null", url : string.Empty, iconCss:"bi-tree-fill"),
                new MenuItemViewModel(id:"sfPlantGenera", text:"Genera", parentId:"sfPlant", url:Url.Action("Index", PlantDataMvcAppControllers.Genus) ?? string.Empty),
                new MenuItemViewModel(id:"sfPlantSpecies", text:"Species", parentId:"sfPlant", url:Url.Action("Index", PlantDataMvcAppControllers.Plant) ?? string.Empty),

                new MenuItemViewModel(id:"sfInv", text:"Inventory", parentId:"null", url : string.Empty, iconCss:"bi-boxes"),
                new MenuItemViewModel(id:"sfInvSeeds", text:"Seeds", parentId:"sfInv", url:Url.Action("Index", PlantDataMvcAppControllers.SeedBatch) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvSites", text:"Seed Collection Sites", parentId:"sfInv", url:Url.Action("Index", @PlantDataMvcAppControllers.Site) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvTrays", text:"Seed Trays", parentId:"sfInv", url:Url.Action("Index", PlantDataMvcAppControllers.SeedTray) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvStock", text:"Plant Stock (static)", parentId:"sfInv", url:Url.Action("Index", @PlantDataMvcAppControllers.PlantStock) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvTransactions", text:"Plant Stock (from Transactions)", parentId:"sfInv", url:Url.Action("StockSummary", PlantDataMvcAppControllers.Transaction) ?? string.Empty),
                new MenuItemViewModel(id:"sfInvStocktake", text:"Plant Stocktake", parentId:"sfInv", url:Url.Action("Stocktake", PlantDataMvcAppControllers.Transaction) ?? string.Empty),

                new MenuItemViewModel(id:"sfSales", text:"Sales", parentId:"null", url : string.Empty, iconCss:"bi-calendar-fill"),
                new MenuItemViewModel(id:"sfSalesEvents", text:"Sale Events", parentId:"sfSales", url:Url.Action("Index", PlantDataMvcAppControllers.SaleEvent) ?? string.Empty),

                new MenuItemViewModel(id:"sfProd", text:"Products and Pricing", parentId:"null", url:string.Empty, iconCss:"bi-currency-dollar"),
                new MenuItemViewModel(id:"sfProdProducts", text:"Products", parentId:"sfProd", url:Url.Action("Index", PlantDataMvcAppControllers.ProductType) ?? string.Empty),
                new MenuItemViewModel(id:"sfProdPricelists", text:"Price Lists", parentId:"sfProd", url:Url.Action("Index", PlantDataMvcAppControllers.PriceListType) ?? string.Empty),

                new MenuItemViewModel(id:"sfPrint", text:"Labels", parentId:"null", url:string.Empty, iconCss:"bi-stickies"),
                new MenuItemViewModel(id:"sfPrintLabels", text:"Information Labels", parentId:"sfPrint", url:Url.Action("Plants", PlantDataMvcAppControllers.Label) ?? string.Empty),
                new MenuItemViewModel(id:"sfPrintBarcodes", text:"Barcode Labels", parentId:"sfPrint", url:Url.Action("Barcodes", PlantDataMvcAppControllers.Label) ?? string.Empty)
            };

            menuModel.MenuItems = menuItems;
            menuModel.MenuFields = new MenuFieldsViewModel()
            { 
                ItemIdField = "Id", 
                TextField = "Text", 
                ParentIdField = "ParentId", 
                UrlField = "Url", 
                IconCssField = "IconCss" 
            };
        }
    }
}
