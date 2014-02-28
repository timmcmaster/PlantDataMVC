using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.UI.Mappers;

namespace PlantDataMvc3.Tests.Controllers
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
