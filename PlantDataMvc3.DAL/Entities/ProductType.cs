﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Entities
{
    /// <summary>
    /// This class is the class for xxxx objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class ProductType : IProductType
    {
        public ProductType()
        {
            ProductPrices = new List<ProductPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<ProductPrice> ProductPrices { get; set; }
        public virtual IList<PlantStock> PlantStock { get; set; }
    }
}
