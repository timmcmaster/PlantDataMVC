﻿using System;
using Framework.DAL.EF;
using Framework.DAL.Entity;
using Framework.DAL.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.DAL.EF
{
    /// <summary>
    /// Do we even need this class?
    /// </summary>
    public abstract class EntityBase : IObjectState, IEntity
    {
        public abstract int Id { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}