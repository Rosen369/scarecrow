using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scarecrow
{
    public class Engine : IEngine
    {
        public Engine(PipelineRegistration pipelineRegistration)
        {
            this._pipelineRegistration = pipelineRegistration;
        }

        private PipelineRegistration _pipelineRegistration;

        public Task<Context> CreateContext(HttpListenerContext hlctx)
        {
            return Task.Factory.StartNew(() =>
            {
                var context = new Context();
                //construct context
                return context;
            });

        }

        public void WriteResponse(HttpListenerResponse hlrsp, Context context)
        {
            throw new NotImplementedException();
        }

        public Task HandleRequest(Context context)
        {
            return Task.Factory.StartNew(() =>
            {
                var pipe = new Pipeline(context, this._pipelineRegistration);
                pipe.ExecuteBeforePipeline();

                //route action

                pipe.ExecuteAfterPipeline();
            });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}