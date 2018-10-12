using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using log4net;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VF.Cotg.WebServer.Startup))]

namespace VF.Cotg.WebServer
{    

    /// <summary>
    /// The Owin Startup Configuration
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Startup));

        /// <summary>
        /// Configure Web Server
        /// </summary>
        /// <param name="app">The AppBuilder</param>
        public void Configuration(IAppBuilder app)
        {
            try
            {
                HttpConfiguration config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}",
                    defaults: new { id=RouteParameter.Optional }
                );
                app.UseWebApi(config);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Configuring WebServer", caught);
                throw;
            }
        }

    }

}
