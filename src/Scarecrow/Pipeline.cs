using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public class Pipeline : IPipeline
    {
        public Pipeline(Context ctx, PipelineRegistration pipelineRegistration)
        {
            this._ctx = ctx;
            this._pipelineRegistration = pipelineRegistration;
        }

        private Context _ctx;

        private PipelineRegistration _pipelineRegistration;

        private IList<IPipelineOp> _beforePipeline = new List<IPipelineOp>();

        private IList<IPipelineOp> _afterPipeline = new List<IPipelineOp>();

        private void GetBeforeActionOp(Context ctx)
        {
            //TODO: implement map op from context
        }

        private void GetAfterActionOp(Context ctx)
        {
            //TODO: implement map op from context
        }

        public void ExecuteAfterPipeline()
        {
            var ap = this._afterPipeline;
            foreach (var op in ap)
            {
                op.ExcuteOperation(_ctx);
            }
        }

        public void ExecuteBeforePipeline()
        {
            var bp = this._beforePipeline;
            foreach (var op in bp)
            {
                op.ExcuteOperation(_ctx);
            }
        }
    }
}
