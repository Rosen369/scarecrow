using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public class Configuration
    {
        public Configuration() : this(new DefaultBootstrapper())
        {
        }

        public Configuration(IBootstrapper bootstrapper) : this(bootstrapper, (e) => { DefaultErrorHandler(e); })
        {
        }

        public Configuration(IBootstrapper bootstrapper, Action<Exception> errorHandler)
        {
            this.Bootstrapper = bootstrapper;
            this.MaximumConnectionCount = ProcessorThreadCount;
            this.ErrorHandler = errorHandler;
            this.PipelineRegistration = new PipelineRegistration();
        }

        public IBootstrapper Bootstrapper { get; private set; }

        public int MaximumConnectionCount { get; set; }

        public Action<Exception> ErrorHandler { get; set; }

        public PipelineRegistration PipelineRegistration { get; private set; }

        public void RegisterBeforePipeline<T>() where T : IPipelineOp
        {
            this.PipelineRegistration.RegisterBeforePipeline<T>();
        }

        public void RegisterAfterPipeline<T>() where T : IPipelineOp
        {
            this.PipelineRegistration.RegisterAfterPipeline<T>();
        }

        private static void DefaultErrorHandler(Exception e)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            Console.WriteLine(time + " -- Error:" + e.Message);
        }

        private static int ProcessorThreadCount
        {
            get
            {
                // Divide by 2 for hyper-threading, and good defaults.
                var threadCount = Environment.ProcessorCount >> 1;
                if (threadCount < 1)
                {
                    return 1;
                }
                return threadCount;
            }
        }
    }
}
