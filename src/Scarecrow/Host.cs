using System;
using System.Net;

namespace Scarecrow
{
    public class Host
    {
        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows xp sp2 or server 2003 is required to use the HttpListener class");
            }
            string[] prefixes = new string[] { "http://localhost:8888/" };
            HttpListener listener = new HttpListener();
            foreach (var item in prefixes)
            {
                listener.Prefixes.Add(item);
            }
            if (!listener.IsListening)
            {
                listener.Start();
            }
            Console.WriteLine("start listening....");
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                Console.WriteLine("{0} {1} HTTP/{2}\r\n", request.HttpMethod, request.RawUrl, request.ProtocolVersion);
                Console.WriteLine("Accept: {0}", string.Join(",", request.AcceptTypes));
                Console.WriteLine("Accept-Language: {0}", string.Join(",", request.UserLanguages));
                Console.WriteLine("Accept-Encoding: {0}", string.Join(",", request.Headers["Accept-Encoding"]));
                Console.WriteLine("User-Agent: {0}", string.Join(",", request.UserAgent));
                Console.WriteLine("Connection: {0}", request.KeepAlive ? "Keep-Alive" : "close");
                Console.WriteLine("Host: {0}", request.UserHostName);
                Console.WriteLine("Pragma: {0}", request.Headers["Pragma"]);
                HttpListenerResponse response = context.Response;
                string responseBody = "<html><head><title>Test</title></head><body><h1>Hello World.</h1></body></html>";
                response.ContentLength64 = System.Text.Encoding.UTF8.GetByteCount(responseBody);
                response.ContentType = "text/html; Charset=UTF-8";
                System.IO.Stream output = response.OutputStream;
                System.IO.StreamWriter sw = new System.IO.StreamWriter(output);
                sw.Write(responseBody);
                sw.Dispose();
                break;
            }
            listener.Close();
            Console.Read();
        }
    }
}
