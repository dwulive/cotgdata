using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VF.Cotg.Data.Models;

namespace VF.Cotg.Services
{

    /// <summary>
    /// The Import Service
    /// </summary>
    public interface IImportService
    {

        void TestImportSingleUnitKillsHistory(DateTime effectiveDate, string playerName, long score, int rank);

        IEnumerable<UnitKillsHistoryModel> GetUnitKillsHistory(DateTime effectiveDate);

    }
}
