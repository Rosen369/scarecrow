using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Scarecrow
{
    public class Host : IDisposable
    {

        public Host(Uri baseUri)
            : this(new Configuration(), baseUri)
        {
        }

        public Host(Configuration configuration, params Uri[] baseUri)
        {
            this._baseUriList = baseUri;
            this._configuration = configuration;
            this._configuration.Bootstrapper.Initialise();
            this._engine = new Engine();
        }

        private readonly IList<Uri> _baseUriList;

        private HttpListener _listener;

        private readonly IEngine _engine;

        private readonly Configuration _configuration;

        private bool _stop = false;

        public void Start()
        {
            if (!HttpListener.IsSupported)
            {
                throw new InvalidOperationException("current operation system is not supported");
            }
            Task.Run(() =>
            {
                var semaphore = new Semaphore(this._configuration.MaximumConnectionCount, this._configuration.MaximumConnectionCount);
                while (!this._stop)
                {
                    semaphore.WaitOne();

                    this._listener.GetContextAsync().ContinueWith(async (contextTask) =>
                    {
                        try
                        {
                            semaphore.Release();
                            var context = await contextTask.ConfigureAwait(false);
                            await this.Process(context).ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            this._configuration.ErrorHandler(ex);
                            throw;
                        }
                    });
                }
            });
        }

        private void StartListener()
        {
            try
            {
                this._listener = new HttpListener();
                foreach (var baseUri in this._baseUriList)
                {
                    var prefix = new UriBuilder(baseUri).ToString();
                    this._listener.Prefixes.Add(prefix);
                }
                this._listener.Start();
            }
            catch (Exception ex)
            {
                this._configuration.ErrorHandler(ex);
                throw;
            }
        }

        private async Task Process(HttpListenerContext ctx)
        {
            try
            {
                using (var context = await this._engine.CreateContext(ctx).ConfigureAwait(false))
                {
                    await this._engine.HandleRequest(context).ConfigureAwait(false);
                    try
                    {
                        this._engine.WriteResponse(ctx.Response, context);
                    }
                    catch (Exception e)
                    {
                        this._configuration.ErrorHandler(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                this._configuration.ErrorHandler(e);
                throw;
            }
        }

        public void Dispose()
        {
            this.Stop();
        }

        private void Stop()
        {
            if (this._listener != null && this._listener.IsListening)
            {
                this._stop = true;
                this._listener.Stop();
            }
        }
    }
}
