using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Microsoft.Owin.Hosting;

namespace VF.Cotg.WebServer
{

    /// <summary>
    /// The WebServer
    /// </summary>
    public class WebServer : IDisposable
    {


        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(WebServer));

        /// <summary>
        /// The WebServer Base URL settings key
        /// </summary>
        public const string WEBSERVER_URL_SETTINGKEY = "webserver.base_url";

        /// <summary>
        /// The WebServer Instance
        /// </summary>
        IDisposable _webServerInstance;

        /// <summary>
        /// The BaseUrl
        /// </summary>
        string _baseUrl;

        /// <summary>
        /// Is the WebServer Instance Running?
        /// </summary>
        public bool Running {
            get {
                return _webServerInstance != null;
            }
        }

        /// <summary>
        /// Initialize WebServer
        /// </summary>
        /// <param name="url">The BaseUrl</param>
        public WebServer(string url)
        {
            try
            {
                _baseUrl = url;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing WebServer", caught);
                throw;
            }
        }

        /// <summary>
        /// Start the WebServer
        /// </summary>
        /// <returns>True if WebServer Started</returns>
        public bool Start()
        {
            try
            {
                logger.Info($"Starting WebService @ {_baseUrl}");
                if (_webServerInstance == null)
                {
                    _webServerInstance = WebApp.Start(_baseUrl);
                }
                return _webServerInstance != null;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Starting WebServer", caught);
                throw;
            }
        }

        /// <summary>
        /// Stop WebServer
        /// </summary>
        /// <returns>True if webServer Stopped</returns>
        public bool Stop()
        {
            try
            {
                logger.Info($"Stopping WebService @ {_baseUrl}");
                if (_webServerInstance != null)
                {
                    _webServerInstance.Dispose();
                    _webServerInstance = null;
                }
                return _webServerInstance == null;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Stopping WebServer", caught);
                throw;
            }
        }

        /// <summary>
        /// Dispose Implementation
        /// </summary>
        public void Dispose()
        {
            try
            {
                Stop();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Cleaning up WebServer", caught);
                throw;
            }
        }
    }
}
