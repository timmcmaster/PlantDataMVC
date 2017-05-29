using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.Entities
{
    /// <summary>
    /// This class is the class for xxxx objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class ProductPrice : IProductPrice
    {
        public int Id
        {
            get { return -1; }
        }
        public int PriceListId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateEffective { get; set; }

        public virtual PriceListType PriceListType { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
