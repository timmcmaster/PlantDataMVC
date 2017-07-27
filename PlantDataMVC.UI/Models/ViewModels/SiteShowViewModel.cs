using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.UI.Models
{
    public class SiteShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Site Name")]
        public string SiteName { get; private set; }

        public string Suburb { get; private set; }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }
        
        //public IList<PlantSeedListViewModel> SeedBatches { get; private set; }

        //public PlantSeedShowViewModel()
        //    : this(0, 0, DateTime.Today, "", "")
        //{
        //    SeedTrays = new List<TrayListViewModel>();
        //}

        //public PlantSeedShowViewModel(int id, int speciesId, DateTime dateCollected, string location, string notes)
        //{
        //    this.Id = id;
        //    this.SpeciesId = speciesId;
        //    this.DateCollected = dateCollected;
        //    this.Location = location;
        //    this.Notes = notes;
        //}
    }
}
