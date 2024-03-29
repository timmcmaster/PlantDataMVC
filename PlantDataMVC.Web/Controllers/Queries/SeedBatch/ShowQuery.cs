﻿using Framework.Web.Views;
using PlantDataMVC.Web.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.Web.Controllers.Queries.SeedBatch
{
    public class ShowQuery : IQuery<SeedBatchShowViewModel>
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}