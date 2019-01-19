using PlantDataMVC.Entities.Models;
using UnitTest.Utils.Common;

namespace UnitTest.Utils.DAL
{
    /// <summary>
    /// Creates random data against the domain objects in the namespace <code>PlantDataMVC.Core.Domain.BusinessObjects</code>
    /// </summary>
    public class SiteBuilder
    {
        // Default members
        public static readonly string DEFAULT_SITE_NAME = "Queensland Centroid";
        public static readonly string DEFAULT_SUBURB = "Muttaburra";
        public static readonly decimal DEFAULT_LATITUDE = -20.917574m;
        public static readonly decimal DEFAULT_LONGITUDE = 142.702789m;

        // private members (for object properties)
        private int _id;
        private string _siteName = DEFAULT_SITE_NAME;
        private string _suburb = DEFAULT_SUBURB;
        private decimal _latitude = DEFAULT_LATITUDE;
        private decimal _longitude = DEFAULT_LONGITUDE;

        private SiteBuilder()
        {
        }

        /// <summary>
        /// Starting point for creating Site test data
        /// </summary>
        /// <returns></returns>
        public static SiteBuilder aSite()
        {
            return new SiteBuilder();
        }

        public SiteBuilder withNoId()
        {
            _id = 0;
            return this;
        }

        public SiteBuilder withId()
        {
            _id = CommonTestData.GeneratRandomInt();
            return this;
        }

        public SiteBuilder withSiteName(string siteName)
        {
            _siteName = siteName;
            return this;
        }

        public SiteBuilder withSuburb(string suburb)
        {
            _suburb = suburb;
            return this;
        }

        public SiteBuilder withLatitude(decimal latitude)
        {
            _latitude = latitude;
            return this;
        }

        public SiteBuilder withLongitude(decimal longitude)
        {
            _longitude = longitude;
            return this;
        }

        public SiteBuilder withRandomValues()
        {
            _id = CommonTestData.GeneratRandomInt();
            _siteName = CommonTestData.GenerateRandomAlphabetString(20);
            _suburb = CommonTestData.GenerateRandomAlphabetString(20);
            _latitude = CommonTestData.GenerateRandomLatitude();
            _longitude = CommonTestData.GenerateRandomLongitude();

            return this;
        }

        public Site Build()
        {
            return new Site()
            {
                Id = _id,
                SiteName = _siteName,
                Suburb = _suburb,
                Latitude = _latitude,
                Longitude = _longitude
            };
        }
    }
}