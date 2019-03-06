// ReSharper disable CheckNamespace

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Interfaces.DAL.Entity;

namespace PlantDataMVC.Entities.Models
{
    partial class Species : Entity
    {
        /// <summary>
        /// Gets the binomial string for this species.
        /// This property is not mapped. It is relevant only to views and not updates.
        /// </summary>
        /// <value>
        /// The binomial string.
        /// </value>
        [NotMapped]
        public string Binomial
        {
            get
            {
                var genericName = Genus.LatinName.Trim();
                var specificName = SpecificName.Trim();

                if (string.IsNullOrEmpty(genericName) && string.IsNullOrEmpty(specificName))
                {
                    return "";
                }
                else if (string.IsNullOrEmpty(genericName))
                {
                    return SpecificName;
                }
                else if (string.IsNullOrEmpty(SpecificName.Trim()))
                {
                    return genericName;
                }
                else
                {
                    return $"{genericName} {specificName}";
                }
            }
        }

    }
}