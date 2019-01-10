using Interfaces.DTO;

namespace PlantDataMVC.DTO.Entities
{
    /// <summary>
    /// This is the base entity used in the business layer.
    /// Interactions between the presentation layer and business layer 
    /// are all done with DomainEntity derived objects.
    /// </summary>
    public abstract class DtoEntity : IDtoEntity
    {
        public virtual int Id { get; set; }
        public virtual string DisplayValue { get; set; }
    }
}
