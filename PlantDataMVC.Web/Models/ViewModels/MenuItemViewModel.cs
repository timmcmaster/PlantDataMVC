using Syncfusion.EJ2.Navigations;
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
        public bool Separator { get; set; }

        public MenuItemViewModel(string id, string text, string parentId, string url, string iconCss = "", bool separator = false)
        {
            Id = id;
            Text = text;
            ParentId = parentId;
            Url = url;
            IconCss = iconCss;
            Separator = separator;
        }

        public static MenuItemViewModel CreateSeparator(string id, string parentId)
        {
            return new MenuItemViewModel(id, string.Empty, parentId, string.Empty, separator: true);
        }
    }
}
