using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Blazor.UIModels.Constants;

namespace PlantData.Web.Blazor.UIModels.ViewModels
{
    public class SidebarMenuViewModel : BaseViewModel, ISidebarMenuViewModel
    {
        private readonly LinkGenerator _linkGen;
        private readonly bool _useBasicHtmlViews;
        public List<MenuItemViewModel> Items { get; set; } = new();
        public MenuFieldsViewModel Fields { get; set; } = new();

        public SidebarMenuViewModel(IConfiguration configuration, NavigationManager navMan, LinkGenerator linkGen) : base(navMan)
        {
            _linkGen = linkGen;
            _useBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public void Initialise()
        {
            LoadItems(_useBasicHtmlViews);
        }

        private void LoadItems(bool useBasicHtmlViews)
        {
            var mainMenuHeaderText = useBasicHtmlViews ? "Menu - Basic Grid" : "Menu - Syncfusion";
            var menuItems = new List<MenuItemViewModel>()
            {
                // Menu header
                new MenuItemViewModel("sfHeader", mainMenuHeaderText, null, string.Empty, "icon"),

                // Home menu
                new MenuItemViewModel("sfHome", "Home",  null,  string.Empty, "bi-house-fill"),
                new MenuItemViewModel("sfHomeHome", "Home", "sfHome",  "/"),
                new MenuItemViewModel("sfHomeAbout", "About", "sfHome",  "about"),
                new MenuItemViewModel("sfHomePrivacy", "Privacy", "sfHome",  "privacy"),

                // Basic MVC Views menu
                new MenuItemViewModel("sfPlant", "Plant Definitions", null, string.Empty, "bi-tree-fill"),
                new MenuItemViewModel("sfPlantGenera", "Genera", "sfPlant",  PlantDataRoutes.Genus),
                new MenuItemViewModel("sfPlantSpecies", "Species", "sfPlant",  PlantDataRoutes.Plant),

                new MenuItemViewModel("sfInv", "Inventory", null, string.Empty, "bi-boxes"),
                new MenuItemViewModel("sfInvSeeds", "Seeds", "sfInv",  PlantDataRoutes.SeedBatch),
                new MenuItemViewModel("sfInvSites", "Seed Collection Sites", "sfInv",  PlantDataRoutes.Site),
                new MenuItemViewModel("sfInvTrays", "Seed Trays", "sfInv",  PlantDataRoutes.SeedTray),
                //new MenuItemViewModel("sfInvStock", "Plant Stock (static)", "sfInv",  _linkGen.GetPathByAction("Index", PlantDataMvcAppControllers.PlantStock) ?? string.Empty),
                //new MenuItemViewModel("sfInvTransactions", "Plant Stock (from Transactions)", "sfInv",  _linkGen.GetPathByAction("StockSummary", PlantDataMvcAppControllers.Transaction) ?? string.Empty),
                //new MenuItemViewModel("sfInvStocktake", "Plant Stocktake", "sfInv",  _linkGen.GetPathByAction("Stocktake", PlantDataMvcAppControllers.Transaction) ?? string.Empty),
                //new MenuItemViewModel("sfInvStocktakeSheets", "Stocktake Sheets", "sfInv",  _linkGen.GetPathByAction("Index", PlantDataMvcAppControllers.StocktakeHeader) ?? string.Empty),

                new MenuItemViewModel("sfSales", "Sales", null, string.Empty, "bi-calendar-fill"),
                new MenuItemViewModel("sfSalesEvents", "Sale Events", "sfSales",  PlantDataRoutes.SaleEvent),

                new MenuItemViewModel("sfProd", "Products and Pricing", null, string.Empty, "bi-currency-dollar"),
                new MenuItemViewModel("sfProdProducts", "Products", "sfProd",  PlantDataRoutes.ProductType),
                //new MenuItemViewModel("sfProdPricelists", "Price Lists", "sfProd",  _linkGen.GetPathByAction("Index", PlantDataMvcAppControllers.PriceListType) ?? string.Empty),

                new MenuItemViewModel("sfPrint", "Labels", null, string.Empty, "bi-stickies"),
                new MenuItemViewModel("sfPrintLabels", "Information Labels", "sfPrint", PlantDataRoutes.PlantLabel),
                new MenuItemViewModel("sfPrintBarcodes", "Barcode Labels", "sfPrint", PlantDataRoutes.BarcodeLabel)
            };

            Items = menuItems;
            Fields = new MenuFieldsViewModel()
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
