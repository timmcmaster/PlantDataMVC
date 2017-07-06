using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.UI.Mappers;

namespace PlantDataMVC.Tests.UI
{
    public class WebMappingFixture
    {
        public WebMappingFixture()
        {
            this.Configure();
        }

        public void Configure()
        {
            AutoMapperBootstrapper.Initialize();

            // or?
            //AutoMapperWebConfiguration.Configure();
        }
    }
}
