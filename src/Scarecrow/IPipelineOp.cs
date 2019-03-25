using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public interface IPipelineOp
    {
        void ExcuteOperation(Context ctx);
    }
}
