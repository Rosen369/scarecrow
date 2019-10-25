using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Scarecrow
{
    public class Request : IDisposable
    {
        public Request(string method, string path, string protocol)
            : this(method, new Uri(path), protocol)
        {
        }

        public Request(string method, Uri uri, string protocol, Stream body = null, RequestHeaders headers = null, X509Certificate certificate = null)
        {
            this.Method = method;
            this.Uri = uri;
            this.Protocol = protocol;
        }

        public RequestHeaders Headers { get; private set; }

        public X509Certificate Certificate { get; private set; }

        public string Protocol { get; private set; }

        public string Method { get; private set; }

        public Uri Uri { get; private set; }

        public string QueryString { get; private set; }

        public Stream Body { get; private set; }

        public IDictionary<string, string> Cookies { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
