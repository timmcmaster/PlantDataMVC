using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    public class PlantStockTransactionType: DomainEntity
    {
        public string Name { get; set; }
        public int Effect { get; set; }

        public PlantStockTransactionType(): this(0, "New Item", 0)
        {
        }

        public PlantStockTransactionType(int id, string name, int effect)
        {
            this.Id = id;
            this.Name = name;
            this.Effect = effect;
        }
    }
}
