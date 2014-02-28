using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantDataMvc3.UI.Models
{
    public class PlantCreateEditModel
    {
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }

        public PlantCreateEditModel()
            : this("", "", "", "", 0, true)
        {
        }

        public PlantCreateEditModel(string genus, string species, string commonName, string description, int propagationTime, bool native)
        {
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Description = description;
            PropagationTime = propagationTime;
            Native = native;
        }
    }
}