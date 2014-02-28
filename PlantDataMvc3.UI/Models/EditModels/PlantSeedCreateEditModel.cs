﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.UI.Models
{
    public class PlantSeedCreateEditModel
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
