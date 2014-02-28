using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.Core.Domain.BusinessObjects
{
    /// <summary>
    /// This is the base entity used in the business layer.
    /// Interactions between the presentation layer and business layer 
    /// are all done with DomainEntity derived objects.
    /// </summary>
    public abstract class DomainEntity
    {
        public virtual int Id { get; set; }
    }
}
