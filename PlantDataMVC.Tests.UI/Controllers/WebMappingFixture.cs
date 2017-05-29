using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.UI.Mappers;

namespace PlantDataMVC.Tests.Controllers
{
    public class WebMappingFixture
    {
        public WebMappingFixture()
        {
        }

        public void Configure()
        {
            AutoMapperBootstrapper.Initialize();

            // or?
            //AutoMapperWebConfiguration.Configure();
        }
    }
}
