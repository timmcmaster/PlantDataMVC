using AutoMapper;
using PlantDataMVC.Domain.Mappers;
using System;

namespace PlantDataMVC.Tests.Core
{
    public class CoreMappingFixture: IDisposable
    {
        public CoreMappingFixture()
        {
            this.Configure();
        }

        public void Configure()
        {
            AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset the mapper each time fixture is torn down
            Mapper.Reset();
        }
    }
}
