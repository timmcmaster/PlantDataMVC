using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class PlantProductType: DomainEntity
    {
        public string Name { get; set; }

        public PlantProductType(): this(0, "New Item")
        {
        }

        public PlantProductType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
