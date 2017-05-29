using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.Core.SimpleServiceLayer;

namespace PlantDataMvc3.UI.ServiceLayerAccess
{
    /// <summary>
    /// Implements the singleton pattern to ensure we only ever have one manager and RepositorySet.
    /// </summary>
    public class ServiceLayerManager
    {
        private static ServiceLayerManager _manager;
        private static IServiceLayer _serviceLayer;

        private ServiceLayerManager()
        {
        }

        public static ServiceLayerManager Instance()
        {
            if (_manager == null)
            {
                _manager = new ServiceLayerManager();
            }

            return _manager;
        }

        /// <summary>
        /// Implements the actual type of service layer we want to use.
        /// </summary>
        /// <returns></returns>
        public IServiceLayer GetServiceLayer()
        {
            if (_serviceLayer == null)
            {
                _serviceLayer = new SimpleServiceLayer();
                //_serviceLayer = new WcfServiceLayer();
            }

            return _serviceLayer;
        }
    }
}

