using Interfaces.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public partial class SaleEventStockEntityModel: IEntity
    {
        public int Id { get; set; }

        public int SaleEventId { get; set; }

        public int SpeciesId { get; set; }

        public int ProductTypeId { get; set; }

        public int Quantity { get; set; }

        public virtual ProductTypeEntityModel ProductType { get; set; } = null!;

        public virtual SaleEventEntityModel SaleEvent { get; set; } = null!;

        public virtual SpeciesEntityModel Species { get; set; } = null!;
    }
}