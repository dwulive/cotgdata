using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Cotg.Common.Settings;
using VF.Cotg.Data;

namespace VF.Cotg.Data.SQLite
{

    /// <summary>
    /// The SQLite Database Manager
    /// </summary>
    public class CotgSQLiteDbManager : IDbManager
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(CotgSQLiteDbManager));

        /// <summary>
        /// The Connection String Settings
        /// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// Initialize SQLite Database Manager
        /// </summary>
        public CotgSQLiteDbManager()
        {
            try
            {
                _connectionStringSettings = DataSettings.ConnectionStringSettings;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Database Manager", caught);
                throw;
            }
        }

        /// <summary>
        /// Determine if Database Exists
        /// </summary>
        /// <returns>True if database file exists</returns>
        public bool DatabaseExists()
        {
            try
            {
                var connectionStringSettings = DataSettings.ConnectionStringSettings;
                var filePath = GetDatabaseFilePath(connectionStringSettings);
                return File.Exists(filePath);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error determining if Database Exists", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Database
        /// </summary>
        public void CreateDatabase()
        {
            try
            {
                logger.Info("Initializing Local Database");

                var connectionStringSettings = DataSettings.ConnectionStringSettings;
                var filePath = GetDatabaseFilePath(connectionStringSettings);
                CreateDatabaseFile(filePath);

                using (var connection = new SQLiteConnection(connectionStringSettings.ConnectionString))
                {
                    connection.Open();
                    logger.Info("Initializing Database Schema");
                    //TODO: Run Schema Creation Helpers

                    logger.Info("Seeding Initial Data");
                    //TODO: Run Seeding Helpers

                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Database", caught);
                throw;
            }
        }

        #region [FileSystem Helpers]

        /// <summary>
        /// Get Database FilePath
        /// </summary>
        /// <param name="connectionStringSettings">The Connection String Settings</param>
        /// <returns>The Database FilePath</returns>
        private string GetDatabaseFilePath(ConnectionStringSettings connectionStringSettings)
        {
            try
            {
                if (connectionStringSettings == null)
                {
                    throw new ArgumentNullException("connectionStringSettings");
                }
                var connectionString = connectionStringSettings.ConnectionString;
                var connectionStringTok = connectionString.Split(new[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries);

                if (connectionStringTok.Length != 2)
                {
                    throw new ApplicationException("Expecting Connection String format to be - URI=file:<filename>");
                }
                var filename = connectionStringTok[1];
                return filename;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Fatabase FilePath", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Database File
        /// </summary>
        /// <param name="filePath">The FilePath</param>
        private void CreateDatabaseFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    throw new ApplicationException("File already exists");
                }

                SQLiteConnection.CreateFile(filePath);
                logger.Info($"Created Database File: {filePath}");
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Database File", caught);
                throw;
            }
        }

        #endregion

        #region [Schema Initialization Helpers]

        #endregion

        #region [Seeding Helpers]

        #endregion

    }
}
