﻿using Framework.Web.Core.Views;
using PlantDataMVC.UICore.Models.ViewModels.Plant;

namespace PlantDataMVC.UICore.Controllers.Queries.Plant
{
    public class DeleteQuery : IQuery<PlantDeleteViewModel>
    {

        public DeleteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}