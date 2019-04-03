using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public class PipelineRegistration
    {
        public PipelineRegistration()
        {
            this.BeforePipeline = new List<Type>();
            this.AfterPipeline = new List<Type>();
        }

        public IList<Type> BeforePipeline { get; private set; }

        public IList<Type> AfterPipeline { get; private set; }

        public void RegisterBeforePipeline<T>() where T : IPipelineOp
        {
            this.BeforePipeline.Add(typeof(T));
        }

        public void RegisterAfterPipeline<T>() where T : IPipelineOp
        {
            this.AfterPipeline.Add(typeof(T));
        }
    }
}
