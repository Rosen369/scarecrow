using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scarecrow
{
    public class Engine : IEngine
    {
        public Context CreateContext(HttpListenerContext hlctx)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void HandleRequest(Context context)
        {
            throw new NotImplementedException();
        }

        public void WriteResponse(HttpListenerResponse hlrsp, Context context)
        {
            throw new NotImplementedException();
        }

        Task IEngine.HandleRequest(Context context)
        {
            throw new NotImplementedException();
        }
    }
}