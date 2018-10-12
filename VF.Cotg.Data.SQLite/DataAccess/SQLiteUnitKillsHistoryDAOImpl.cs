using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Cotg.Common.Settings;
using VF.Cotg.Common.Utility;
using VF.Cotg.Data.Models;
using VF.Cotg.Data.DataAccess;

namespace VF.Cotg.Data.SQLite.DataAccess
{

    /// <summary>
    /// The SQLite Unit Kills History DataAccess Implementation
    /// </summary>
    /// <remarks>
    /// Need to find out if players can disappear, or have any need to "delete"
    /// Under this model would have to use an expiry date field, that might have to be added...
    /// </remarks>
    public class SQLiteUnitKillsHistoryDAOImpl : BaseDAO, IUnitKillsHistoryDAO
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteUnitKillsHistoryDAOImpl));

        /// <summary>
        /// Initialize SQLite Unit Kills History DataAccess Implementation
        /// </summary>
        /// <param name="dbManager"></param>
        public SQLiteUnitKillsHistoryDAOImpl(IDbManager dbManager) : base(DataSettings.ConnectionStringSettings, dbManager) {}

        /// <summary>
        /// Get Unit Kills History
        /// </summary>
        /// <param name="effectiveDate">The Effective Date</param>
        /// <returns>The Unit Kills History</returns>
        public IEnumerable<UnitKillsHistoryModel> GetUnitKillsHistory(DateTime effectiveDate)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      UKH.* " +
                    $" FROM " +
                    $"      {CotgDataContract.UnitKillsHistory.TABLE_NAME} UKH " +
                    $" WHERE " +
                    $"      NOT EXISTS ( " +
                    $"          SELECT 1 " +
                    $"          FROM {CotgDataContract.UnitKillsHistory.TABLE_NAME} UKH2 " +
                    $"          WHERE " +
                    $"              UKH2.{CotgDataContract.UnitKillsHistory.COLUMN_PLAYERNAME_NAME} = UKH.{CotgDataContract.UnitKillsHistory.COLUMN_PLAYERNAME_NAME} " +
                    $"              AND UKH2.{CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME} > UKH.{CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME} " +
                    $"              AND UKH2.{CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME} <=@effectiveDate " +
                    $"      ) " +
                    $"      AND UKH.{CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME} <= @effectiveDate " +
                    $" ORDER BY " +
                    $"      UKH.{CotgDataContract.UnitKillsHistory.COLUMN_SCORE_NAME} DESC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter("@effectiveDate", DbType.Double, DateUtility.DateToEpoch(effectiveDate)));

                        var results = new List<UnitKillsHistoryModel>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var unitKillsHistoryModel = new Models.SQLiteUnitKillsHistoryModel(reader);
                                results.Add(unitKillsHistoryModel);
                            }
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Unit Kills History", caught);
                throw;
            }
        }

        /// <summary>
        /// Insert Unit Kills History
        /// </summary>
        /// <param name="playerName">The Player Name</param>
        /// <param name="effectiveDate">The Effective Date</param>
        /// <param name="score">The Score</param>
        /// <param name="rank">The Rank</param>
        public void InsertUnitKillsHistory(string playerName, DateTime effectiveDate, long score, int rank)
        {
            try
            {
                string sql =
                    $" INSERT INTO {CotgDataContract.UnitKillsHistory.TABLE_NAME} ( " +
                    $"      {CotgDataContract.UnitKillsHistory.COLUMN_PLAYERNAME_NAME}, " +
                    $"      {CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME}, " +
                    $"      {CotgDataContract.UnitKillsHistory.COLUMN_SCORE_NAME}, " +
                    $"      {CotgDataContract.UnitKillsHistory.COLUMN_RANK_NAME} " +
                    $" ) VALUES ( " +
                    $"      @playerName, @effectiveDate, @score, @rank " +
                    $" ) ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter("@playerName", DbType.String, playerName));
                        command.Parameters.Add(CreateParameter("@effectiveDate", DbType.Double, DateUtility.DateToEpoch(effectiveDate)));
                        command.Parameters.Add(CreateParameter("@score", DbType.Int64, score));
                        command.Parameters.Add(CreateParameter("@rank", DbType.Int32, rank));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Inserting Unit Kills History Record", caught);
                throw;
            }
        }

    }
}
