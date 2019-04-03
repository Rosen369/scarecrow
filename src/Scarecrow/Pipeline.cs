using System;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public class Pipeline : IPipeline
    {
        public Pipeline(Context ctx)
        {
            this._ctx = ctx;
        }

        private Context _ctx;

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
