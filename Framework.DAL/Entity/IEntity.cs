using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.DAL.Entity
{
    /// <summary>
    /// This interface is the basic interface for entity objects passed outside the DAL.
    /// Interactions between the Data Access Layer and the Business Layer 
    /// are all done with IEntity-derived objects. 
    /// Each object type should have an IEntity derived class to contain type-specific properties
    /// </summary>
    public interface IEntity
    {
        int Id { get; }
    }  
}