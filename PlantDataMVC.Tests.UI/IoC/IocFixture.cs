using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.UI;
using Autofac;

namespace PlantDataMVC.Tests.UI
{
    public class IocFixture
    {
        public IContainer container { get; set; }

        public IocFixture()
        {
            this.Configure();
        }

        public void Configure()
        {
            container = AutofacConfig.ConfigureContainer();
        }
    }
}
