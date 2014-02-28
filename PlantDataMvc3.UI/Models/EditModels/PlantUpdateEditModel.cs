using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantDataMvc3.UI.Models
{
    public class PlantUpdateEditModel
    {
        public int Id { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public int PropagationTime { get; set; }
        public bool Native { get; set; }

        public PlantUpdateEditModel()
            : this(0, "", "", "", "", 0, true)
        {
        }

        public PlantUpdateEditModel(int id, string genus, string species, string commonName, string description, int propagationTime, bool native)
        {
            Id = id;
            Genus = genus;
            Species = species;
            CommonName = commonName;
            Description = description;
            PropagationTime = propagationTime;
            Native = native;
        }
    }
}