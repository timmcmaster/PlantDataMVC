using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.Core.Mappers;

namespace PlantDataMvc3.Tests.Core
{
    public class CoreMappingFixture
    {
        public CoreMappingFixture()
        {
        }

        public void Configure()
        {
            AutoMapperCoreConfiguration.Configure();
        }
    }
}
