using System;
using System.Collections.Generic;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.UI.ServiceLayerAccess;

namespace PlantDataMvc3.UI.Helpers
{
    public static class FormHandlerFactory
    {
        private static Dictionary<Type, Object> _formHandlerDictionary = new Dictionary<Type, object>();

        public static IFormHandler<TForm> GetFormHandler<TForm>()
        {
            IFormHandler<TForm> formHandler = FindHandler<TForm>();

            if (formHandler == null)
            {
                formHandler = CreateHandler<TForm>();
                AddHandler<TForm>(formHandler);
            }

            return formHandler;
        }

        public static dynamic GetDataService<TForm>()
        {
            if ((typeof(TForm) == typeof(PlantCreateEditModel)) ||
                (typeof(TForm) == typeof(PlantDestroyEditModel)) ||
                (typeof(TForm) == typeof(PlantUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<Plant>();
            }
            else if ((typeof(TForm) == typeof(PlantSeedCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantSeedDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantSeedUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantSeed>();
            }
            else if ((typeof(TForm) == typeof(PlantStockEntryCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockEntryDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockEntryUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockEntry>();
            }
            else if ((typeof(TForm) == typeof(PlantStockTransactionCreateEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockTransactionDestroyEditModel)) ||
                    (typeof(TForm) == typeof(PlantStockTransactionUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockTransaction>();
            }
            else if ((typeof(TForm) == typeof(TrayCreateEditModel)) ||
                    (typeof(TForm) == typeof(TrayDestroyEditModel)) ||
                    (typeof(TForm) == typeof(TrayUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantSeedTray>();
            }
            else if ((typeof(TForm) == typeof(SiteCreateEditModel)) ||
                    (typeof(TForm) == typeof(SiteDestroyEditModel)) ||
                    (typeof(TForm) == typeof(SiteUpdateEditModel)))
            {
                return ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantSeedSite>();
            }
            else
            {
                return null;
            }
        }

        private static IFormHandler<TForm> FindHandler<TForm>()
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

        private static IFormHandler<TForm> CreateHandler<TForm>()
        {
            var dataService = GetDataService<TForm>();

            // Use convention that handler type name will be form type name + "FormHandler"
            string formTypeName = typeof(TForm).Name;
            string handlerNamespace = "PlantDataMvc3.UI.Helpers.Handlers";
            String handlerFullTypeName = String.Format("{0}.{1}FormHandler", handlerNamespace, formTypeName);

            // Get the type
            Type handlerType = Type.GetType(handlerFullTypeName);

            // Create the instance from the type
            IFormHandler<TForm> formHandler = (IFormHandler<TForm>)Activator.CreateInstance(handlerType, new object[] { dataService });

            return formHandler;
        }

        private static void AddHandler<TForm>(IFormHandler<TForm> handler)
        {
            if (FindHandler<TForm>() == null)
            {
                _formHandlerDictionary.Add(typeof(TForm), handler);
            }
        }

    }
}