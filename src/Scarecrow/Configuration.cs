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

        public Configuration(IBootstrapper bootstrapper)
        {
            this.Bootstrapper = bootstrapper;
            this.MaximumConnectionCount = ProcessorThreadCount;
        }

        public IBootstrapper Bootstrapper { get; private set; }

        public int MaximumConnectionCount { get; set; }

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
