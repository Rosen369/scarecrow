using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scarecrow
{
    public class Engine : IEngine
    {
        public Task<Context> CreateContext(HttpListenerContext hlctx)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void WriteResponse(HttpListenerResponse hlrsp, Context context)
        {
            throw new NotImplementedException();
        }

        public Task HandleRequest(Context context)
        {
            throw new NotImplementedException();
        }
    }
}