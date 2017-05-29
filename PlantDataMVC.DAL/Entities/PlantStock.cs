﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.Entities
{
    /// <summary>
    /// This class is the class for PlantStock objects passed outside the DAL.
    /// Other implementations are mapped to an object of this type.
    /// </summary>
    public class PlantStock : IPlantStock
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Species Species { get; set; }
        public virtual IList<JournalEntry> JournalEntries { get; set; }
    }
 }