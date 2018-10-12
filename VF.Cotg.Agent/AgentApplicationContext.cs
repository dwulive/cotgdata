using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using Ninject;

namespace VF.Cotg.Agent
{

    /// <summary>
    /// The Agent Application Context
    /// </summary>
    /// <remarks>
    /// Will have to wire-up Ninject kernel for data and service implementations
    /// </remarks>
    public class AgentApplicationContext : ApplicationContext
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(AgentApplicationContext));

        /// <summary>
        /// The Kernel
        /// </summary>
        private static StandardKernel _kernel;

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
                _kernel = InitializeContainer();
                _baseUrl = GetWebServerBaseUrl();
                _webServer = new WebServer.WebServer(_baseUrl);
                var importService = _kernel.Get<Services.IImportService>();
                MainForm = new MainForm(_webServer, importService);
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
        /// <remarks>
        /// TODO: This should be moved to the settings namespace
        /// </remarks>
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

        /// <summary>
        /// Initialize IOC Container
        /// </summary>
        /// <returns>The IoC Container</returns>
        static StandardKernel InitializeContainer()
        {
            try
            {
                logger.Info("Initializing IoC Container");

                var kernel = new StandardKernel();

                var configuredDataProvider = Common.Settings.DataSettings.DataProvider;
                if (Common.Settings.DataSettings.PROVIDER_SQLITE.Equals(configuredDataProvider))
                {
                    logger.Info("Installing SQLite Data Dependancies");
                    InstallSQLiteDependencies(kernel);
                }

                kernel.Bind<Services.IImportService>()
                    .To<Services.Standard.StandardImportServiceImpl>()
                    .InSingletonScope();

                return kernel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Container", caught);
                throw;
            }
        }

        /// <summary>
        /// Install SQLite Dependencies
        /// </summary>
        /// <param name="kernel">The Kernel</param>
        static void InstallSQLiteDependencies(StandardKernel kernel)
        {
            try
            {
                kernel.Bind<Data.DataAccess.IUnitKillsHistoryDAO>()
                    .To<Data.SQLite.DataAccess.SQLiteUnitKillsHistoryDAOImpl>()
                    .InSingletonScope();
                kernel.Bind<Data.IDbManager>()
                    .To<Data.SQLite.CotgSQLiteDbManager>()
                    .InSingletonScope();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Installing SQLite Depenencies", caught);
                throw;
            }
        }

        #endregion

    }
}
