﻿using System;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.SeedBatch
{
    public class SeedBatchCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        public DateTime DateCollected { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public int SiteId { get; set; }
    }
}
