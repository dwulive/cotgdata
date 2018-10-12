using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Cotg.Data.DataAccess;
using VF.Cotg.Data.Models;

namespace VF.Cotg.Services.Standard
{

    /// <summary>
    /// The Standard Import Service Implementation
    /// </summary>
    /// <remarks>
    /// TODO: Will have to make an interface that combines all data access objects, 
    /// otherwise this will get a little unruly
    /// </remarks>
    public class StandardImportServiceImpl : IImportService
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(StandardImportServiceImpl));

        /// <summary>
        /// The Unit Kills History DataAccess Object
        /// </summary>
        private IUnitKillsHistoryDAO _unitKillsHistoryDAO;

        /// <summary>
        /// Initialize Standard Import Service Implementation
        /// </summary>
        /// <param name="unitKillsHistoryDAO">The Unit Kills History DataAccess Object</param>
        public StandardImportServiceImpl(IUnitKillsHistoryDAO unitKillsHistoryDAO)
        {
            try
            {
                _unitKillsHistoryDAO = unitKillsHistoryDAO;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Standard Import Service Implementation", caught);
                throw;
            }
        }

        /// <summary>
        /// Just a test method to verify Data Components are functioning as intended
        /// </summary>
        /// <param name="effectiveDate">The Effective Date</param>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        /// <param name="rank"></param>
        public void TestImportSingleUnitKillsHistory(DateTime effectiveDate, string playerName, long score, int rank)
        {
            try
            {
                _unitKillsHistoryDAO.InsertUnitKillsHistory(playerName, effectiveDate, 100000, 17);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Importing Single Unit Kills History Record", caught);
                throw;
            }
        }

        public IEnumerable<UnitKillsHistoryModel> GetUnitKillsHistory(DateTime effectiveDate)
        {
            try
            {
                var unitKillsHistory = _unitKillsHistoryDAO.GetUnitKillsHistory(effectiveDate);
                return unitKillsHistory;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Unit Kills History", caught);
                throw;
            }
        }

    }
}
