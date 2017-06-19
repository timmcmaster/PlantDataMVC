using Framework.Domain;

namespace PlantDataMVC.Domain.Entities
{
    /// <summary>
    /// This is the base entity used in the business layer.
    /// Interactions between the presentation layer and business layer 
    /// are all done with DomainEntity derived objects.
    /// </summary>
    public abstract class DomainEntity : IDomainEntity
    {
        public virtual int Id { get; set; }
    }
}
