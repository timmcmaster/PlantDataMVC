using System;

namespace PlantDataMVC.UI.Helpers
{
    public class LinkHeader
    {
        public Uri FirstPageLink { get; set; }
        public Uri PrevPageLink { get; set; }
        public Uri NextPageLink { get; set; }
        public Uri LastPageLink { get; set; }
    }
}