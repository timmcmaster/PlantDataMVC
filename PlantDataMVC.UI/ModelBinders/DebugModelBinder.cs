using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantDataMVC.UI.ModelBinders
{
    // Create a debug binder just to let us step into model binder generally
    public class DebugModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var boundData = base.BindModel(controllerContext, bindingContext);

            return boundData;
        }
    }
}