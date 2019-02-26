// ReSharper disable CheckNamespace
using Interfaces.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class ProductPrice : Entity
    {
        // HACK: Putting Id in just to meet interface requirements
        public override int Id
        {
            get => -1;
            set { }
        }
    }
}