using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Cotg.Data.DataAccess
{

    /// <summary>
    /// The Base DataAccess Object
    /// </summary>
    public class BaseDAO
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(BaseDAO));

        /// <summary>
        /// The Connection String Settings
        /// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// The Databaes Provider Factory
        /// </summary>
        private DbProviderFactory _dbFactory;

        /// <summary>
        /// Initialize BaseDAO
        /// </summary>
        public BaseDAO()
        {
            try
            {
                
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing BaseDAO", caught);
                throw;
            }
        }



    }
}
