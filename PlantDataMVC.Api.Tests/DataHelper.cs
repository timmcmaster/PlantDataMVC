using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMvc.WebApiCore.Tests
{
    public static class DataHelper
    {
        public static SpeciesDataModel GetSpeciesDtoTest1()
        {
            var species = new SpeciesDataModel
            {
                CommonName = "Brisbane wattle",
                Description = "Small tree to 10m",
                GenusId = 1,
                GenusName = "Acacia",
                Id = 1,
                Native = true,
                PropagationTime = 17,
                SpecificName = "fimbriata",
                PlantStocks = new List<PlantStockDataModel>
                {
                    new PlantStockDataModel
                    {
                        Id = 2, ProductTypeId = 1, SpeciesId = 1, QuantityInStock = 10
                    },
                    new PlantStockDataModel
                    {
                        Id = 3, ProductTypeId = 2, SpeciesId = 1, QuantityInStock = 5
                    }
                },
                SeedBatches = new List<SeedBatchDataModel>
                {
                    new SeedBatchDataModel
                    {
                        Id = 6, DateCollected = new DateTime(2016, 1, 30), SpeciesId = 1, Location = "Home",
                        Notes = "Notes 1"
                    },
                    new SeedBatchDataModel
                    {
                        Id = 3, DateCollected = new DateTime(2018, 11, 3), SpeciesId = 1, Location = "Grandchester",
                        Notes = "Notes 2"
                    },
                    new SeedBatchDataModel
                    {
                        Id = 11, DateCollected = new DateTime(2017, 7, 23), SpeciesId = 1, Location = "Tingalpa",
                        Notes = "Notes 3"
                    }
                }
            };

            return species;
        }

        public static TreeNode<string> GetFixedFieldTree(string fieldList)
        {
            TreeNode<string> tree = new TreeNode<string>("");

            switch (fieldList)
            {
                case "":
                    break;
                case "commonName":
                    tree.AddChild("commonName");
                    break;
                case "commonName,plantStocks.quantityInStock,seedBatches.DateCollected,seedBatches.location":
                    tree.AddChild("commonName");
                    tree.AddChild("plantStocks").AddChild("quantityInStock");
                    tree.AddChild("seedBatches").AddChildren(new string[] { "DateCollected", "location" });
                    break;
                case "emaNnommoc":
                    tree.AddChild("emaNnommoc");
                    break;
                case "emaNnommoc,skcotStnalp.kcotSnIytitnauq,sehctaBdees.detcelloCetaD,sehctaBdees.noitacol":
                    tree.AddChild("emaNnommoc");
                    tree.AddChild("skcotStnalp").AddChild("kcotSnIytitnauq");
                    tree.AddChild("sehctaBdees").AddChildren(new string[] { "detcelloCetaD", "noitacol" });
                    break;
            }

            return tree;
        }
    }
}
