using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.UI.Models
{
    public class SiteCreateEditModel
    {
        public string SiteName { get; set; }
        public string Suburb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
