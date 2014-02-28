using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Entities
{
    /// <summary>
    /// This class is the class for Genus objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class Genus : IGenus
    {
        public Genus()
        {
            Species = new List<Species>();
        }

        public int Id { get; set; }
        public string LatinName { get; set; }

        public virtual IList<Species> Species { get; set; }
    }
}
