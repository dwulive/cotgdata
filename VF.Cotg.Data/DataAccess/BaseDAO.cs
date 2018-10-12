using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Cotg.Common.Settings;

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

        ///// <summary>
        ///// The Connection String Settings
        ///// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// The Databaes Provider Factory
        /// </summary>
        private DbProviderFactory _dbFactory;

        /// <summary>
        /// The Database Manager
        /// </summary>
        protected IDbManager _dbManager;

        /// <summary>
        /// Initialize BaseDAO
        /// </summary>
        public BaseDAO(ConnectionStringSettings connectionStringSettings, IDbManager dbManager)
        {
            try
            {
                _connectionStringSettings = connectionStringSettings;
                _dbFactory = CreateDbProviderFactory(_connectionStringSettings);
                _dbManager = dbManager;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing BaseDAO", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Connection String Settings
        /// </summary>
        /// <param name="connectionStringName">The Connection String Name</param>
        /// <returns>The Connection String Settings</returns>
        protected ConnectionStringSettings GetConnectionStringSettings(string connectionStringName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connectionStringName))
                {
                    throw new ArgumentNullException("connectionStringName");
                }
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
                if (connectionStringName == null)
                {
                    throw new ApplicationException($"Connection String '{connectionStringName}' does not exist");
                }
                return connectionStringSettings;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Connection String Settings", caught);
                throw;
            }
        }

        /// <summary>
        /// Create DbProviderFactory
        /// </summary>
        /// <param name="connectionStringSettings">The ConnectionString Settings</param>
        /// <returns>The DbProvider Factory</returns>
        protected DbProviderFactory CreateDbProviderFactory(ConnectionStringSettings connectionStringSettings)
        {
            try
            {
                if (connectionStringSettings == null)
                {
                    throw new ArgumentNullException("connectionStringSettings");
                }
                var providerName = connectionStringSettings.ProviderName;
                var factory = DbProviderFactories.GetFactory(providerName);
                return factory;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating DbProviderFactory", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <returns>The Connection</returns>
        protected DbConnection CreateConnection()
        {
            try
            {
                var connection = _dbFactory.CreateConnection();
                connection.ConnectionString = _connectionStringSettings.ConnectionString;
                return connection;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Connection", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Command
        /// </summary>
        /// <param name="connection">The Connection</param>
        /// <param name="commandType">The Command Type</param>
        /// <param name="commandText">The Command Text</param>
        /// <returns></returns>
        protected DbCommand CreateCommand(DbConnection connection, CommandType commandType, string commandText)
        {
            try
            {
                if (connection == null)
                {
                    throw new ArgumentNullException("connection");
                }
                if (string.IsNullOrWhiteSpace(commandText))
                {
                    throw new ArgumentNullException("commandText");
                }
                var command = _dbFactory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                return command;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Command", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Parameter
        /// </summary>
        /// <param name="parameterName">The Parameter Name</param>
        /// <param name="dbType">The Data Type</param>
        /// <param name="value">The Value</param>
        /// <returns>The Parameter</returns>
        protected DbParameter CreateParameter(string parameterName, DbType dbType, object value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(parameterName))
                {
                    throw new ArgumentNullException("parameterName");
                }
                var parameter = _dbFactory.CreateParameter();
                parameter.ParameterName = parameterName;
                parameter.DbType = dbType;
                parameter.Value = value;
                return parameter;
            }
            catch (Exception caught)
            {
                logger.Error("Unepxected Error Creating Parameter", caught);
                throw;
            }
        }

        #region [Repository Initialization helpers]

        /// <summary>
        /// Initialize Repository
        /// </summary>
        internal void InitializeDatabase()
        {
            try
            {
                if (_dbManager == null)
                {
                    logger.Warn("Database Manager Not Registered, Unable to Initialize Repository");
                    return;
                }

                if (!_dbManager.DatabaseExists())
                {
                    logger.Warn("Database does not exist... Initializing");
                    _dbManager.CreateDatabase();
                    logger.Warn("Database Initialized");
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpecetd Error Initializing Repository", caught);
                throw;
            }
        }

        #endregion

    }
}
