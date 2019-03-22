using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scarecrow
{
    public class Context : IDisposable
    {
        public Context()
        {
            this.Items = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Items { get; private set; }

        public Request Request { get; set; }

        public Response Response { get; set; }

        public void Dispose()
        {
            foreach (var disposableItem in this.Items.Values.OfType<IDisposable>())
            {
                disposableItem.Dispose();
            }

            this.Items.Clear();

            if (this.Request != null)
            {
                this.Request.Dispose();
            }

            if (this.Response != null)
            {
                this.Response.Dispose();
            }
        }
    }
}
