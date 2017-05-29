using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace PlantDataMVC.UI.Helpers.ViewResults
{
    /// <summary>
    /// A class for post-processing a View to map it's model from the current type to the defined type.
    /// </summary>
    public class PreProcessingViewResult : ViewResult
    {
        /// <summary>
        /// The child ViewResult which we actually want to execute.
        /// </summary>
        public ViewResult Child { get; private set; }

        public PreProcessingViewResult(ViewResult child)
        {
            Child = child;
        }

        /// <summary>
        /// The main method for any ViewResult.
        /// This method runs the process task, then calls the lowest level ExecuteResult
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            // Do pre-processing before we execute the base result
            RunPreProcessing();

            // Call ExecuteResult on the base level result
            GetRootViewResult().ExecuteResult(context);
        }

        /// <summary>
        /// Method to return the base level ViewResult which we want to execute
        /// </summary>
        /// <returns></returns>
        public virtual ViewResult GetRootViewResult()
        {
            if (Child is PreProcessingViewResult)
            {
                return ((PreProcessingViewResult)Child).GetRootViewResult();
            }
            else
            {
                return Child;
            }
        }

        /// <summary>
        /// Method to pre-process the content of the base ViewResult
        /// </summary>
        public virtual void RunPreProcessing()
        {
            // Run the child's preprocessing
            if (Child is PreProcessingViewResult)
            {
                ((PreProcessingViewResult)Child).RunPreProcessing();
            }

            // then run our task
            PreProcessingTask();
        }

        /// <summary>
        /// Task that will be run to pre-process the content of the base ViewResult
        /// </summary>
        protected virtual void PreProcessingTask()
        {
        }
    }
}