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
    public class BasicProcessTaskViewResult : ProcessTaskViewResult
    {
        /// <summary>
        /// The child ViewResult which we actually want to execute.
        /// </summary>
        public ViewResult Child { get; private set; }

        public BasicProcessTaskViewResult(ViewResult child):base()
        {
            Child = child;
        }

        /// <summary>
        /// Method to return the base level view result which we want to execute
        /// </summary>
        /// <returns></returns>
        public override ViewResult GetRootViewResult()
        {
            return Child;
        }

        /// <summary>
        /// </summary>
        public override void ProcessTask()
        {
        }
    }
}