using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public interface IPipeline
    {
        void ExecuteBeforePipeline();

        void ExecuteAfterPipeline();
    }
}
