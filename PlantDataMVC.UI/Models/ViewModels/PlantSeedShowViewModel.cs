using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.UI.Models
{
    public class PlantSeedShowViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; private set; }

        [Display(Name = "Species Id")]
        public int SpeciesId { get; private set; }

        [Display(Name = "Date Collected")]
        public DateTime DateCollected { get; private set; }
        
        public string Location { get; private set; }
        
        public string Notes { get; private set; }
        
        public IList<TrayListViewModel> SeedTrays { get; private set; }

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
