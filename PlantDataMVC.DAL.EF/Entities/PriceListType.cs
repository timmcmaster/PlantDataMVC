//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace PlantDataMVC.DAL.EF.Entities
{
    public partial class PriceListType
    {
        public PriceListType()
        {
            this.ProductPrices = new HashSet<ProductPrice>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
    
        internal virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
    
}