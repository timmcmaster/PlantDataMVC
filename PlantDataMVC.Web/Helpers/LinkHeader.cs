using System;

namespace PlantDataMVC.Web.Helpers
{
    public class LinkHeader
    {
        public Uri FirstPageLink { get; set; }
        public Uri PrevPageLink { get; set; }
        public Uri NextPageLink { get; set; }
        public Uri LastPageLink { get; set; }
    }
}