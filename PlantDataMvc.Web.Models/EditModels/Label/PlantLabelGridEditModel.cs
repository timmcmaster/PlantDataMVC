﻿using Framework.Web.Forms;
using System.Collections.Generic;

namespace PlantDataMVC.Web.Models.EditModels.Label
{
    public class PlantLabelGridEditModel : IForm<string>
    {
        public IEnumerable<PlantLabelListEditModel> Items { get; set; } = new List<PlantLabelListEditModel>();
    }
}