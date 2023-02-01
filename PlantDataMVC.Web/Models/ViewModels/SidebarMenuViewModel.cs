﻿using Syncfusion.EJ2.Navigations;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewModels
{
    public class SidebarMenuViewModel
    {
        public string TargetCss { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string DockWidth { get; set; } = string.Empty;
        public MenuViewModel Menu { get; set; } = new();
    }
}
