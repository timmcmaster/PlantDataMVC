﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.EF.Infrastructure;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFMappingFixture
    {
        public EFMappingFixture()
        {
        }

        public void Configure()
        {
            AutoMapperDALConfigurationEF.Configure();
        }
    }
}