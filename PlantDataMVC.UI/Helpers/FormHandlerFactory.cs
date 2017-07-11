using System;
using System.Collections.Generic;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;
using Framework.Service.ServiceLayer;

namespace PlantDataMVC.UI.Helpers
{
    public class FormHandlerFactory: IFormHandlerFactory
    {
        private IServiceLayer _serviceLayer;

        private Dictionary<Type, Object> _formHandlerDictionary = new Dictionary<Type, object>();

        // TODO: Remove dependency on IServiceLayer, should be only on data service needed for given form type 
        public FormHandlerFactory(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
            _formHandlerDictionary = new Dictionary<Type, object>();
        }

        public IFormHandler<TForm> GetFormHandler<TForm>()
        {
            IFormHandler<TForm> formHandler = FindHandler<TForm>();

            if (formHandler == null)
            {
                formHandler = CreateHandler<TForm>();
                AddHandler<TForm>(formHandler);
            }

            return formHandler;
        }

        public dynamic GetDataService<TForm>()
        {
            if ((typeof(TForm) == typeof(PlantCreateEditModel)) ||
                (typeof(TForm) == typeof(PlantDestroyEditModel)) ||
                (typeof(TForm) == typeof(PlantUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<Plant>();
            }
            else if ((typeof(TForm) == typeof(PlantSeedCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantSeedDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantSeedUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<PlantSeed>();
            }
            else if ((typeof(TForm) == typeof(PlantStockEntryCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockEntryDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockEntryUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<PlantStockEntry>();
            }
            else if ((typeof(TForm) == typeof(PlantStockTransactionCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockTransactionDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockTransactionUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<PlantStockTransaction>();
            }
            else if ((typeof(TForm) == typeof(TrayCreateEditModel)) ||
                    (typeof(TForm) == typeof(TrayDestroyEditModel)) ||
                    (typeof(TForm) == typeof(TrayUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<PlantSeedTray>();
            }
            else if ((typeof(TForm) == typeof(SiteCreateEditModel)) ||
                    (typeof(TForm) == typeof(SiteDestroyEditModel)) ||
                    (typeof(TForm) == typeof(SiteUpdateEditModel)))
            {
                return _serviceLayer.GetDataService<PlantSeedSite>();
            }
            else
            {
                return null;
            }
        }

        private IFormHandler<TForm> FindHandler<TForm>()
        {
            if (_formHandlerDictionary.ContainsKey(typeof(TForm)))
            {
                return (IFormHandler<TForm>)_formHandlerDictionary[typeof(TForm)];
            }
            else
            {
                return null;
            }
        }

        private IFormHandler<TForm> CreateHandler<TForm>()
        {
            var dataService = GetDataService<TForm>();

            // Use convention that handler type name will be form type name + "FormHandler"
            string formTypeName = typeof(TForm).Name;
            string handlerNamespace = "PlantDataMVC.UI.Helpers.Handlers";
            String handlerFullTypeName = String.Format("{0}.{1}FormHandler", handlerNamespace, formTypeName);

            // Get the type
            Type handlerType = Type.GetType(handlerFullTypeName);

            // Create the instance from the type
            IFormHandler<TForm> formHandler = (IFormHandler<TForm>)Activator.CreateInstance(handlerType, new object[] { dataService });

            return formHandler;
        }

        private void AddHandler<TForm>(IFormHandler<TForm> handler)
        {
            if (FindHandler<TForm>() == null)
            {
                _formHandlerDictionary.Add(typeof(TForm), handler);
            }
        }

    }
}