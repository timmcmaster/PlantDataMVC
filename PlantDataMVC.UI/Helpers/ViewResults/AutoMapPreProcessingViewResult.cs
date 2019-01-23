using AutoMapper;
using System;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Helpers.ViewResults
{
    /// <inheritdoc />
    /// <summary>
    /// A class for post-processing a View to map it's model from the current type to the defined type.
    /// </summary>
    public class AutoMapPreProcessingViewResult : PreProcessingViewResult
    {
        public Type SourceType { get; }
        public Type DestinationType { get; }

        public AutoMapPreProcessingViewResult(Type sourceType, Type destinationType, PreProcessingViewResult child)
            : base(child)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        protected override void PreProcessingTask()
        {
            ViewResult viewResult = GetRootViewResult();

            // Map the model in the very base view to the required type 
            var model = Mapper.Map(viewResult.ViewData.Model, SourceType, DestinationType);

            // Set the model in the view to the new type
            viewResult.ViewData.Model = model;
        }
    }
}