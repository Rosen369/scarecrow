using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public interface IPipelineFactory
    {
        Pipeline Create(Context ctx);
    }
}
