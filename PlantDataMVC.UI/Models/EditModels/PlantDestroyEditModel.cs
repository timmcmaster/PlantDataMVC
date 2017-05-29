using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    public class PlantDestroyEditModel
    {
        public int Id { get; set; }

        public PlantDestroyEditModel()
            : this(0)
        {
        }

        public PlantDestroyEditModel(int id)
        {
            Id = id;
        }
    }
}