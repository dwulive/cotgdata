using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Cotg.Common.Utility;
using VF.Cotg.Data.Models;

namespace VF.Cotg.Data.SQLite.Models
{

    /// <summary>
    /// The SQLite Unit Kills History Model
    /// </summary>
    public class SQLiteUnitKillsHistoryModel : UnitKillsHistoryModel
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteUnitKillsHistoryModel));

        /// <summary>
        /// Is the Model Bound?
        /// </summary>
        private static bool _bound = false;

        /// <summary>
        /// The ID Index
        /// </summary>
        private static int _indexID;

        /// <summary>
        /// The PlayerName Index
        /// </summary>
        private static int _indexPlayerName;

        /// <summary>
        /// The EffectiveDate Index
        /// </summary>
        private static int _indexEffectiveDate;

        /// <summary>
        /// The Score Index
        /// </summary>
        private static int _indexScore;

        /// <summary>
        /// The Rank Index
        /// </summary>
        private static int _indexRank;

        /// <summary>
        /// Initialize Unit Kills History Model
        /// </summary>
        public SQLiteUnitKillsHistoryModel() {}

        /// <summary>
        /// Initialize Unit Kills History Model with DataReader
        /// </summary>
        /// <param name="reader">The DataReader</param>
        public SQLiteUnitKillsHistoryModel(IDataReader reader)
        {
            try
            {
                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }
                RealizeColumnMappings(reader);
                ID = reader.GetInt64(_indexID);
                PlayerName = reader.GetString(_indexPlayerName);
                EffectiveDate = DateUtility.EpochToDate(reader.GetDouble(_indexEffectiveDate));
                Score = reader.GetInt64(_indexScore);
                Rank = reader.GetInt32(_indexRank);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Unit Kills History model", caught);
                throw;
            }
        }

        /// <summary>
        /// Realize Column Mappings
        /// </summary>
        /// <param name="reader"></param>
        private static void RealizeColumnMappings(IDataReader reader)
        {
            try
            {
                if (_bound)
                {
                    return;
                }
                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }

                _indexID = reader.GetOrdinal(CotgDataContract.UnitKillsHistory.COLUMN_ID_NAME);
                _indexPlayerName = reader.GetOrdinal(CotgDataContract.UnitKillsHistory.COLUMN_PLAYERNAME_NAME);
                _indexEffectiveDate = reader.GetOrdinal(CotgDataContract.UnitKillsHistory.COLUMN_EFFECTIVEDATE_NAME);
                _indexScore = reader.GetOrdinal(CotgDataContract.UnitKillsHistory.COLUMN_SCORE_NAME);
                _indexRank = reader.GetOrdinal(CotgDataContract.UnitKillsHistory.COLUMN_RANK_NAME);

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Realizing Column Mappings", caught);
                throw;
            }
        }

    }
}
