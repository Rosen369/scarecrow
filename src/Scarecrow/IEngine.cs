using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scarecrow
{
    public interface IEngine : IDisposable
    {
        Task HandleRequest(Context context);

        Task<Context> CreateContext(HttpListenerContext hlctx);

        void WriteResponse(HttpListenerResponse hlrsp, Context context);
    }
}
