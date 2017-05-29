using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace PlantDataUI.Helpers
{
    /// <summary>
    /// A class for post-processing a View to map it's model from the current type to the defined type.
    /// </summary>
    public class AutoMapProcessTaskCompositeViewResult : ProcessTaskCompositeViewResult
    {
        public Type SourceType { get; private set; }
        public Type DestinationType { get; private set; }

        public AutoMapProcessTaskCompositeViewResult(Type sourceType, Type destinationType, ProcessTaskViewResult child): base(child)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        protected override void Task()
        {
            ViewResult viewResult = GetRootViewResult();

            // Automap the model in the very base view to the required type 
            var model = Mapper.Map(viewResult.ViewData.Model, SourceType, DestinationType);

            // Set the model in the view to the new type
            viewResult.ViewData.Model = model;
        }
    }
}