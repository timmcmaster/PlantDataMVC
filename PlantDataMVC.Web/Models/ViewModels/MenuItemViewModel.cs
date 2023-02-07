﻿using Syncfusion.EJ2.Navigations;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.ViewModels
{
    public class MenuItemViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
        public string IconCss { get; set; }

        public MenuItemViewModel(string id, string text, string parentId, string url, string iconCss = "")
        {
            Id = id;
            Text = text;
            ParentId = parentId;
            Url = url;
            IconCss = iconCss;
        }
    }
}