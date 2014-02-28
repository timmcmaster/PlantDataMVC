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
    public abstract class ProcessTaskCompositeViewResult : ProcessTaskViewResult
    {
        public ProcessTaskCompositeViewResult(ProcessTaskViewResult child): base(child)
        {
        }

        protected abstract void Task();

        public override void ProcessTask()
        {
            // do child task
            ((ProcessTaskViewResult)Child).ProcessTask();

            // then do our task
            Task();
        }

        /// <summary>
        /// Method to return the base level view result which we want to execute
        /// </summary>
        /// <returns></returns>
        public override ViewResult GetRootViewResult()
        {
            ProcessTaskViewResult viewResult = (ProcessTaskViewResult)Child;
            while (viewResult.Child is ProcessTaskViewResult)
            {
                viewResult = (ProcessTaskViewResult)viewResult.Child;
            }

            return viewResult.Child;
        }

        //public override void ExecuteResult(ControllerContext context)
        //{
        //    ProcessTask();

        //    GetRootViewResult().ExecuteResult(context);
        //}
    }
}