using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

namespace VF.Cotg.Agent
{

    /// <summary>
    /// The Agent Application Context
    /// </summary>
    public class AgentApplicationContext : ApplicationContext
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(AgentApplicationContext));

        /// <summary>
        /// The BaseUrl
        /// </summary>
        private string _baseUrl;

        /// <summary>
        /// The WebServer
        /// </summary>
        private WebServer.WebServer _webServer;

        /// <summary>
        /// Initialize Agent ApplicationContext
        /// </summary>
        public AgentApplicationContext()
        {
            try
            {
                _baseUrl = GetWebServerBaseUrl();
                _webServer = new WebServer.WebServer(_baseUrl);
                MainForm = new MainForm(_webServer);
            }
            catch (Exception caught)
            {
                logger.Fatal("Unable to Initialize Application Context", caught);
                MessageBox.Show("An unexpected error has occurred while trying to start " +
                    "the Crown of the Gods Data Collection Agent.  It is recommended to " +
                    "review the log files for more information.", 
                    "Crown of the Gods - Agent Fatal Startup Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                Environment.FailFast("Unable to start!", caught);
            }
        }

        #region [Helpers]

        /// <summary>
        /// Get the Base URl Setting
        /// </summary>
        /// <returns>The Base URl Setting</returns>
        private string GetWebServerBaseUrl()
        {
            try
            {
                var baseUrl = ConfigurationManager.AppSettings[WebServer.WebServer.WEBSERVER_URL_SETTINGKEY];
                if (string.IsNullOrWhiteSpace(baseUrl))
                {
                    throw new ApplicationException("The WebServer BaseURL is not congfigured");
                }

                Uri validateUri;
                if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out validateUri) 
                    || !(validateUri.Scheme == Uri.UriSchemeHttp || validateUri.Scheme == Uri.UriSchemeHttps))
                {
                    throw new ApplicationException("The Configured BaseURL is not a valid Http or Https address");
                }


                return baseUrl;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Base Url Setting", caught);
                throw;
            }
        }

        #endregion

    }
}
