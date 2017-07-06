using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Domain.Mappers;

namespace PlantDataMVC.Tests.Core
{
    public class CoreMappingFixture
    {
        public CoreMappingFixture()
        {
            this.Configure();
        }

        public void Configure()
        {
            AutoMapperCoreConfiguration.Configure();
        }
    }
}
