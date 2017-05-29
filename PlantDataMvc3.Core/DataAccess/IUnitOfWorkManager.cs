using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMvc3.Core.DataAccess
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork GetUnitOfWork();
    }
}
