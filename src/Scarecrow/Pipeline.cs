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
            this.BeforePipeline = new List<IPipelineOp>();
            this.AfterPipeline = new List<IPipelineOp>();
        }

        private Context _ctx;

        public IList<IPipelineOp> BeforePipeline { get; private set; }

        public IList<IPipelineOp> AfterPipeline { get; private set; }

        private void AddBeforePipe()
        {
            throw new NotImplementedException();
        }

        private void AddAfterPipe()
        {
            throw new NotImplementedException();
        }

        private void AddBeforeAction()
        {
            throw new NotImplementedException();
        }

        private void AddAfterAction()
        {
            throw new NotImplementedException();
        }

        public void ExecuteAfterPipeline()
        {
            var ap = this.AfterPipeline;
            foreach (var op in ap)
            {
                op.ExcuteOperation(_ctx);
            }
        }

        public void ExecuteBeforePipeline()
        {
            var bp = this.BeforePipeline;
            foreach (var op in bp)
            {
                op.ExcuteOperation(_ctx);
            }
        }
    }
}
