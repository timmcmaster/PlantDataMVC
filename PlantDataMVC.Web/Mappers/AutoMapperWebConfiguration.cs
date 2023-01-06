using AutoMapper;
using System;

namespace PlantDataMVC.UICore.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(ConfigAction);
        }

        public static Action<IMapperConfigurationExpression> ConfigAction
            = cfg =>
            {
                cfg.AddProfile<UIToDataModelMappingProfile>();
                cfg.AddProfile<DataModelToUIMappingProfile>();
            };
    }
}