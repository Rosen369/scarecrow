using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scarecrow
{
    public class RequestHeaders : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
    {
        private readonly IDictionary<string, IEnumerable<string>> headers;

        public RequestHeaders()
        {
            this.headers = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
        }

        public RequestHeaders(IDictionary<string, IEnumerable<string>> headers)
        {
            this.headers = new Dictionary<string, IEnumerable<string>>(headers, StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
