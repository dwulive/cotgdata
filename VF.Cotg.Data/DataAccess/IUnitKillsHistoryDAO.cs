using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VF.Cotg.Data.Models;

namespace VF.Cotg.Data.DataAccess
{

    /// <summary>
    /// The Unit Kills History Data Access Object
    /// </summary>
    public interface IUnitKillsHistoryDAO
    {

        /// <summary>
        /// Get Unit Kills History 
        /// </summary>
        /// <param name="effectiveDate">The Effective Date</param>
        /// <returns>The Unit Kills History</returns>
        IEnumerable<UnitKillsHistoryModel> GetUnitKillsHistory(DateTime effectiveDate);

        /// <summary>
        /// Insert Unit Kills History Record
        /// </summary>
        /// <param name="playerName">The Player Name</param>
        /// <param name="effectiveDate">The Effective Date</param>
        /// <param name="score">The Score</param>
        /// <param name="rank">The Ranking</param>
        void InsertUnitKillsHistory(string playerName, DateTime effectiveDate, long score, int rank);

    }
}
