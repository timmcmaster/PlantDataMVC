﻿// ReSharper disable CheckNamespace

using Interfaces.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantDataMVC.Entities.EntityModels
{
    public partial class JournalEntryTypeEntityModel: IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name (length: 50)

        [Required]
        [Display(Name = "Effect")]
        public int Effect { get; set; } // Effect

        // Reverse navigation

        /// <summary>
        /// Child JournalEntries where [JournalEntry].[JournalEntryTypeId] point to this entity (FK_Transactions_TransactionType)
        /// </summary>
        public virtual ICollection<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry.FK_Transactions_TransactionType

        public JournalEntryTypeEntityModel()
        {
            JournalEntries = new List<JournalEntryEntityModel>();
        }
    }

}
