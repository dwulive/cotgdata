using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.Models
{

    /// <summary>
    /// The Caverns History Model
    /// </summary>
    public class CavernsHistoryModel
    {

        /// <summary>
        /// The Row Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Player Name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// The Row Effective Date
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// The Player Score
        /// </summary>
        public long Score { get; set; }

        /// <summary>
        /// The Player Rank
        /// </summary>
        public int Rank { get; set; }

    }
}
